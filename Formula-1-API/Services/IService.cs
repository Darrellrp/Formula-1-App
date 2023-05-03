using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;

namespace Formula_1_API.Services
{
    public interface IService<T> where T : class, IEntity
    {
        Task<DbResult<T>> GetAll();
        Task<DbResult<T>> GetPaginated(int page, int limit = 100);
        Task<DbResult<T>?> FindById(int id);
        Task<DbResult<T>> Where(Expression<Func<T, bool>> expression);
        Task<T> Save(T entity);
        Task<DbResult<T>> Save(IEnumerable<T> entities);
        Task<T> Update(int id, T entity);
        Task Delete(T entity);
    }
}
