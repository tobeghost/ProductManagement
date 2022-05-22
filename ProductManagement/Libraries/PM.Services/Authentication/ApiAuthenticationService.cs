using PM.Domain.Customers;
using PM.Services.Customers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Authentication
{
    public partial class ApiAuthenticationService : IApiAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICustomerService _customerService;

        private Customer _cachedCustomer;
        private string _errorMessage;
        private string _username;

        public ApiAuthenticationService(IHttpContextAccessor httpContextAccessor, ICustomerService customerService)
        {
            _httpContextAccessor = httpContextAccessor;
            _customerService = customerService;
        }

        /// <summary>
        /// Valid
        /// </summary>
        /// <param name="customer">Customer</param>
        public virtual async Task<bool> Valid(TokenValidatedContext context)
        {
            _username = context.Principal.Claims.FirstOrDefault(x => x.Type == "Username")?.Value;

            if (string.IsNullOrEmpty(_username))
            {
                _errorMessage = "Username not exists in the context";
                return await Task.FromResult(false);
            }

            var customer = await _customerService.GetCustomerByUsername(_username);
            if (customer == null || !customer.Active)
            {
                _errorMessage = "Username not exists/or not active in the customer table";
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

        public virtual async Task SignIn()
        {
            if (string.IsNullOrEmpty(_username))
                throw new ArgumentNullException(nameof(_username));

            await SignIn(_username);
        }

        /// <summary>
        /// Sign in
        /// </summary>
        ///<param name="username">Username</param>
        public virtual async Task SignIn(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            var customer = await _customerService.GetCustomerByUsername(username);
            if (customer != null)
                _cachedCustomer = customer;
        }


        /// <summary>
        /// Get error message
        /// </summary>
        /// <returns></returns>
        public virtual Task<string> ErrorMessage()
        {
            return Task.FromResult(_errorMessage);
        }

        /// <summary>
        /// Get authenticated customer
        /// </summary>
        /// <returns>Customer</returns>
        public virtual async Task<Customer> GetAuthenticatedCustomer()
        {
            //whether there is a cached customer
            if (_cachedCustomer != null)
                return _cachedCustomer;

            Customer customer = null;

            //try to get authenticated user identity
            string authHeader = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization];
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith(JwtBearerDefaults.AuthenticationScheme))
                return null;

            var authenticateResult = await _httpContextAccessor.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);
            if (!authenticateResult.Succeeded)
                return null;

            //try to get customer by email
            var usernameClaim = authenticateResult.Principal.Claims.FirstOrDefault(claim => claim.Type == "Username");
            if (usernameClaim != null)
                customer = await _customerService.GetCustomerByUsername(usernameClaim.Value);


            //whether the found customer is available
            if (customer == null || !customer.Active)
                return null;

            //cache authenticated customer
            _cachedCustomer = customer;

            return _cachedCustomer;
        }
    }
}
