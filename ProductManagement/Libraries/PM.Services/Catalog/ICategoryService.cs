using PM.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Catalog
{
    public partial interface ICategoryService
    {
        Task InsertCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Category category);
        Task DeleteCategoryById(int categoryId);
        Task<IEnumerable<Category>> GetAllCategories(bool showHidden = false);
        Task<Category> GetCategoryById(int categoryId);
    }
}
