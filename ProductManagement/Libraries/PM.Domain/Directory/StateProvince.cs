using PM.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Domain.Directory
{
    /// <summary>
    /// Represents a state province
    /// </summary>
    public partial class StateProvince : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country identifier
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the country entity
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the state provinces for a customer address
        /// </summary>
        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
    }
}
