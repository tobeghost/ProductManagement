using Newtonsoft.Json;
using PM.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Domain.Catalog
{
    /// <summary>
    /// Represents a product
    /// </summary>
    [JsonObject(IsReference = true)]
    public partial class Product : BaseEntity
    {
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the barcode of product
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
        /// </summary>
        public string Gtin { get; set; }

        /// <summary>
        /// Gets or sets the short description
        /// </summary>
        public string ShortDescription { get; set; }
        /// <summary>
        /// Gets or sets the full description
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the old price
        /// </summary>
        public decimal OldPrice { get; set; }

        /// <summary>
        /// Gets or sets the catalog price
        /// </summary>
        public decimal CatalogPrice { get; set; }

        /// <summary>
        /// Gets or sets the product cost price
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency entity
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the categories for a product
        /// </summary>
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is active
        /// </summary>
        public bool Active { get; set; }
    }
}
