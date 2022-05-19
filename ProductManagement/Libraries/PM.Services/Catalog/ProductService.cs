﻿using PM.Core.Caching;
using PM.Domain.Catalog;
using PM.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Catalog
{
    /// <summary>
    /// Product service
    /// </summary>
    public partial class ProductService : IProductService
    {
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

            var entity = await _productRepository.GetByIdAsync(productId);
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
            if (showHidden)
            {
                return await _productRepository.FindAsync(row => row.Active);
            }
            else
            {
                return await _productRepository.GetAllAsync();
            }
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

            return await _productRepository.GetByIdAsync(productId);
        }
    }
}
