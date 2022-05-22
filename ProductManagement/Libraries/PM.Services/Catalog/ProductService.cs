using Microsoft.EntityFrameworkCore;
using PM.Core.Caching;
using PM.Domain.Catalog;
using PM.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Catalog
{
    /// <summary>
    /// Product service
    /// </summary>
    public partial class ProductService : IProductService
    {
        private const string CACHEKEY_ALLPRODUCTS = "PM.Services.Product.all-{0}";
        private const string CACHEKEY_ALLPRODUCTS_BY_CATEGORYID = "PM.Services.Product.category-{0}-{1}";
        private const string CACHEKEY_ALLPRODUCTS_BY_ID = "PM.Services.Product.id-{0}";

        private readonly ICacheService _cache;
        private readonly IRepository<Product> _productRepository;

        public ProductService(ICacheService cache, IRepository<Product> productRepository)
        {
            _cache = cache;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Inserts a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            await _productRepository.AddAsync(product);
        }

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            await _productRepository.UpdateAsync(product);
        }

        /// <summary>
        /// Delete the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task DeleteProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            await _productRepository.RemoveAsync(product);
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public virtual async Task DeleteProductById(int productId)
        {
            if (productId < 0)
                throw new ArgumentNullException("productId");

            var entity = _productRepository.GetById(productId);
            if (entity == null)
                throw new Exception("Not found product");

            await _productRepository.RemoveAsync(entity);
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Product>> GetAllProducts(bool showHidden = false)
        {
            var key = string.Format(CACHEKEY_ALLPRODUCTS, showHidden);
            return await _cache.GetOrCreate(key, async () =>
            {
                if (showHidden)
                {
                    return await _productRepository.Table.Where(row => row.Active)
                                                         .Include(row => row.ProductCategories)
                                                         .ThenInclude(row => row.Category)
                                                         .Include(row => row.Currency)
                                                         .ToListAsync();
                }
                else
                {
                    return await _productRepository.Table.Include(row => row.ProductCategories)
                                                         .ThenInclude(row => row.Category)
                                                         .Include(row => row.Currency)
                                                         .ToListAsync();
                }
            });
        }

        /// <summary>
        /// Gets all products by category id
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId, bool showHidden = false)
        {
            var key = string.Format(CACHEKEY_ALLPRODUCTS_BY_CATEGORYID, categoryId, showHidden);
            return await _cache.GetOrCreate(key, async () =>
            {
                if (showHidden)
                {
                    return await _productRepository.Table.Where(row => row.ProductCategories.Any(o => o.CategoryId == categoryId) && row.Active)
                                                         .Include(row => row.ProductCategories)
                                                         .ThenInclude(row => row.Category)
                                                         .Include(row => row.Currency)
                                                         .ToListAsync();
                }
                else
                {
                    return await _productRepository.Table.Where(row => row.ProductCategories.Any(o => o.CategoryId == categoryId))
                                                         .Include(row => row.ProductCategories)
                                                         .ThenInclude(row => row.Category)
                                                         .Include(row => row.Currency)
                                                         .ToListAsync();
                }
            });
        }

        /// <summary>
        /// Gets a product 
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product</returns>
        public virtual async Task<Product> GetProductById(int productId)
        {
            if (productId <= 0)
                return null;

            var key = string.Format(CACHEKEY_ALLPRODUCTS_BY_ID, productId);
            return await _cache.GetOrCreate(key, async () =>
            {
                return await _productRepository.Table.Where(row => row.Id == productId)
                                                 .Include(row => row.ProductCategories)
                                                 .ThenInclude(row => row.Category)
                                                 .Include(row => row.Currency)
                                                 .FirstOrDefaultAsync();
            });
        }

        /// <summary>
        /// Change status of product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="status">Set true for active else passive</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual async Task ChangeStatusOfProductById(int productId, bool status)
        {
            if (productId <= 0)
                throw new ArgumentNullException("productId");

            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new ArgumentNullException("product");

            product.Active = status;

            await _productRepository.UpdateAsync(product);
        }
    }
}
