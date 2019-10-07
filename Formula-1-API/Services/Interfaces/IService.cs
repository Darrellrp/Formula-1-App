using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;

namespace Formula_1_API.Services.Interfaces
{
    public interface IService<T> where T : IIdentifier
    {
        Task<List<T>> GetAll();
        Task<T> FindById(int id);
        Task<List<T>> Where(Expression<Func<T, bool>> expression);
        Task<T> Save(T entity);
        Task<List<T>> Save(List<T> entities);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
