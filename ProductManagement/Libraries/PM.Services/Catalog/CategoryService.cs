using PM.Core.Caching;
using PM.Domain.Catalog;
using PM.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Catalog
{
    /// <summary>
    /// Category service
    /// </summary>
    public partial class CategoryService : ICategoryService
    {
        private readonly ICacheService _cache;
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(ICacheService cache, IRepository<Category> categoryRepository)
        {
            _cache = cache;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Inserts a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task InsertCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            await _categoryRepository.AddAsync(category);
        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            await _categoryRepository.UpdateAsync(category);
        }

        /// <summary>
        /// Delete the category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task DeleteCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            await _categoryRepository.RemoveAsync(category);
        }

        /// <summary>
        /// Delete category by id
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public virtual async Task DeleteCategoryById(int categoryId)
        {
            if (categoryId < 0)
                throw new ArgumentNullException("categoryId");

            var entity = _categoryRepository.GetById(categoryId);
            if (entity == null)
                throw new Exception("Not found category");

            await _categoryRepository.RemoveAsync(entity);
        }

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Category>> GetAllCategories(bool showHidden = false)
        {
            if (showHidden)
            {
                return _categoryRepository.Find(row => row.Active);
            }
            else
            {
                return _categoryRepository.GetAll();
            }
        }

        /// <summary>
        /// Gets a category 
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category</returns>
        public virtual async Task<Category> GetCategoryById(int categoryId)
        {
            if (categoryId <= 0)
                return null;

            return _categoryRepository.GetById(categoryId);
        }
    }
}
