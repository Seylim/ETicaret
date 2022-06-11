using Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<IList<T>> GetAllEntitiesAsync();
        Task<T> GetEntityByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> IsExistsAsync(int id);
    }
}
