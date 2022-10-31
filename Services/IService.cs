using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_App.Models;

namespace Formula_1_App.Services
{
    public interface IService<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetPaginated(int page, int limit = 100);
        Task<T?> FindById(int id);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> expression);
        Task<T> Save(T entity);
        Task<IEnumerable<T>> Save(IEnumerable<T> entities);
        Task<T> Update(int id, T entity);
        Task Delete(T entity);
    }
}
