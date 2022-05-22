using System.Collections.Generic;

namespace ProductManagement.API.Models.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Gtin { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string Currency { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public bool Active { get; set; }
    }
}
