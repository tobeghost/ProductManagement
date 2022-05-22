using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PM.Core.Configuration;
using PM.Core.Extensions;
using PM.Services.Customers;
using ProductManagement.API.Jwt;
using ProductManagement.API.Models;
using ProductManagement.API.Models.Login;
using ProductManagement.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtAuthenticationConfig _jwtConfig;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public LoginController(
            JwtAuthenticationConfig jwtConfig,
            ICustomerService customerService,
            IMapper mapper
        )
        {
            _jwtConfig = jwtConfig;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("token")]
        public async Task<IActionResult> Token(string username, string password)
        {
            var re = new TokenResponse();

            try
            {
                var user = await _customerService.GetCustomerByUsername(username);
                if (user == null)
                {
                    re.AddError("User not exists");
                    return BadRequest(re);
                }

                if (user.Password != password)
                {
                    re.AddError("Password doesn't match");
                    return BadRequest(re);
                }

                var token = new JwtTokenBuilder();
                token.AddSecurityKey(JwtSecurityKey.Create(_jwtConfig.SecretKey));
                token.AddExpiry(_jwtConfig.ExpiryInMinutes);

                if (_jwtConfig.ValidateIssuer) token.AddIssuer(_jwtConfig.ValidIssuer);
                if (_jwtConfig.ValidateAudience) token.AddAudience(_jwtConfig.ValidAudience);

                var claims = new Dictionary<string, string>();
                claims.Add("Username", username);
                token.AddClaims(claims);

                var jwt = token.Build();

                var signIn = _mapper.Map<SignInDto>(user);
                signIn.Token = jwt.Value;
                signIn.ExpiryInMinutes = _jwtConfig.ExpiryInMinutes;

                re.Success(signIn);
            }
            catch (Exception ex)
            {
                re.Error(ex);
            }

            return Ok(re);
        }
    }
}
