using PM.Domain.Customers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Authentication
{
    public partial interface IApiAuthenticationService
    {
        /// <summary>
        /// Sign in
        /// </summary>
        Task SignIn();

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="username">username</param>
        Task SignIn(string username);

        /// <summary>
        /// Valid 
        /// </summary>
        ///<param name="context">Token</param>
        Task<bool> Valid(TokenValidatedContext context);

        /// <summary>
        /// Get error message
        /// </summary>
        /// <returns></returns>
        Task<string> ErrorMessage();

        Task<Customer> GetAuthenticatedCustomer();
    }
}
