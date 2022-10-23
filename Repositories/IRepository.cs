using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_App.Models;

namespace Formula_1_App.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T?> FindById(int id);
        Task<List<T>> Where(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll();
        Task<List<T>> GetPaginated(int page, int limit = 100);
        Task<T> Add(T entity);
        Task<List<T>> AddMany(List<T> entities);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
