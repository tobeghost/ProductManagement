using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Domain.Catalog
{
    /// <summary>
    /// Represents a category
    /// </summary>
    [JsonObject(IsReference = true)]
    public partial class Category : BaseEntity
    {
        /// <summary>
        /// Gets or sets the parent category identifier
        /// </summary>
        public int ParentCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the products for a category
        /// </summary>
        public virtual ICollection<ProductCategory> Products { get; set; }
    }
}
