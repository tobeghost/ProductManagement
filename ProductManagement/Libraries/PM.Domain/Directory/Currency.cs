using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Domain.Directory
{
    /// <summary>
    /// Represents a currency
    /// </summary>
    public partial class Currency : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the rate
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets the number of decimal places (for RoundPrice)
        /// </summary>
        public int NumberDecimal { get; set; } = 2;

        /// <summary>
        /// Gets or sets a value indicating whether the entity is status
        /// </summary>
        public bool Status { get; set; }
    }
}
