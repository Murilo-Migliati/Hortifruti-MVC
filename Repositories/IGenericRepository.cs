using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiMvc.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entidade);
        Task UpdateAsync(T entidade);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
        
}