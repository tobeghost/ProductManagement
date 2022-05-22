using PM.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Catalog
{
    public partial interface IProductService
    {
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
        Task DeleteProductById(int productId);
        Task<IEnumerable<Product>> GetAllProducts(bool showHidden = false);
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId, bool showHidden = false);
        Task<Product> GetProductById(int productId);
        Task ChangeStatusOfProductById(int productId, bool status);
    }
}
