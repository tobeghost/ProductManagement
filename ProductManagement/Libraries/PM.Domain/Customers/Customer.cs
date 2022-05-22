using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Domain.Customers
{
    /// <summary>
    /// Represents a customer
    /// </summary>
    [JsonObject(IsReference = true)]
    public partial class Customer : BaseEntity
    {
        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer account is admin
        /// </summary>
        public bool IsAdministrator { get; set; }

        /// <summary>
        /// Gets or sets the address for a customer
        /// </summary>
        public virtual ICollection<CustomerAddress> Address { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is active
        /// </summary>
        public bool Active { get; set; }
    }
}
