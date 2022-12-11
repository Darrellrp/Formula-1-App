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
        Task<T?> FindById(int id);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetPaginated(int page, int limit = 100);
        Task<T> Add(T entity);
        Task<IEnumerable<T>> AddMany(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<int> Count();
    }
}
