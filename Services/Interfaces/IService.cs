using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_App.Models;

namespace Formula_1_App.Services.Interfaces
{
    public interface IService<T> where T : IIdentifier
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetPaginated(int page, int limit = 100);
        Task<T?> FindById(int id);
        Task<List<T>> Where(Expression<Func<T, bool>> expression);
        Task<T> Save(T entity);
        Task<List<T>> Save(List<T> entities);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
