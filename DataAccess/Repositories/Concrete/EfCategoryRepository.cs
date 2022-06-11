using DataAccess.Data;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private ETicaretContext dbContext;
        public EfCategoryRepository(ETicaretContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddAsync(Category entity)
        {
            await dbContext.Categories.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
        }

        public IList<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }

        public async Task<IList<Category>> GetAllEntitiesAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetEntityByIdAsync(int id)
        {
            return await dbContext.Categories.FindAsync(id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await dbContext.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<int> UpdateAsync(Category entity)
        {
            dbContext.Categories.Update(entity);
            return await dbContext.SaveChangesAsync();
        }
    }
}
