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
    public class EfProductRepository : IProductRepository
    {
        private ETicaretContext dbContext;
        public EfProductRepository(ETicaretContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddAsync(Product entity)
        {
            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            product.isActive = false;
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Product>> GetAllEntitiesAsync()
        {
            return await dbContext.Products.Where(p => p.isActive == true).ToListAsync();
        }

        public async Task<Product> GetEntityByIdAsync(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await dbContext.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<IList<Product>> SearchProductByNameAsync(string productName)
        {
            return await dbContext.Products.Where(p => p.Name.Contains(productName)).ToListAsync();
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            dbContext.Products.Update(entity);
            return await dbContext.SaveChangesAsync();
        }
    }
}
