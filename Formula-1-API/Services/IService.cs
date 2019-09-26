using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Formula_1_API.Services
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> FindById(int id);
        Task<List<T>> Where(Expression<Func<T, bool>> expression);
        Task<T> Save(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
