using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.Persistence.Contracts;
public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetPaginatedAsync(int pageNumber, int pageSize);
    Task<T> GetAsync(Guid id);
    Task<bool> EntityExists(Guid id);
    Task<int> CountAsync();
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
