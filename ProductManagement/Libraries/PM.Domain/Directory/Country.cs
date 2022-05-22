using Newtonsoft.Json;
using PM.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Domain.Directory
{
    /// <summary>
    /// Represents a country
    /// </summary>
    [JsonObject(IsReference = true)]
    public partial class Country : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the two letter ISO code
        /// </summary>
        public string TwoLetterIsoCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the state provinces for a country
        /// </summary>
        public virtual ICollection<StateProvince> StateProvinces { get; set; }

        /// <summary>
        /// Gets or sets the state provinces for a customer address
        /// </summary>
        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
    }
}
