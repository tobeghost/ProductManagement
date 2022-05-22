using Newtonsoft.Json;
using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Domain.Customers
{
    /// <summary>
    /// Represents a customer address
    /// </summary>
    [JsonObject(IsReference = true)]
    public partial class CustomerAddress : BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the country identifier
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the state/province identifier
        /// </summary>
        public int StateProvinceId { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address 1
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the zip/postal code
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the customer entity
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the country entity
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets the state province entity
        /// </summary>
        public virtual StateProvince StateProvince { get; set; }
    }
}
