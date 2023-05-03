using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;

namespace Formula_1_API.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<DbResult<T>?> FindById(int id);
        Task<DbResult<T>> Where(Expression<Func<T, bool>> expression);
        Task<DbResult<T>> GetAll();
        Task<DbResult<T>> GetPaginated(int page, int limit = 100);
        Task<T> Add(T entity);
        Task<DbResult<T>> AddMany(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<int> Count();
    }
}
