using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Domain.Catalog
{
    /// <summary>
    /// Represents a product category
    /// </summary>
    [JsonObject(IsReference = true)]
    public partial class ProductCategory : BaseEntity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the category identifier
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category entity
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets the product entity
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
