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
        /// Gets or sets the related country id
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the related country entity
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is status
        /// </summary>
        public bool Status { get; set; }
    }
}
