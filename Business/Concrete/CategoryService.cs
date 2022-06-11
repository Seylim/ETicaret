using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;
        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            return await repository.AddAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public IList<Category> GetCategories()
        {
            return repository.GetAll();
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await repository.GetAllEntitiesAsync();
        }

        public async Task<Category> GetEntityByIdAsync(int id)
        {
            return await repository.GetEntityByIdAsync(id);
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await repository.IsExistsAsync(id);
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            return await repository.UpdateAsync(category);
        }
    }
}
