using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IList<Category> GetCategories();
        Task<int> AddCategoryAsync(Category category);
        Task<int> UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Task<IList<Category>> GetCategoriesAsync();
        Task<Category> GetEntityByIdAsync(int id);
        Task<bool> IsExistAsync(int id);
    }
}
