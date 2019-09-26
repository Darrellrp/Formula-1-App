using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Repositories;
using Formula_1_API.Models;
using Formula_1_API.Services;

namespace Formula_1_API.Services
{
    public class BaseService<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> repository;

        public BaseService(IRepository<T> _repository)
        {
            this.repository = _repository;
        }

        public async Task<List<T>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<T> FindById(int id)
        {
            return await repository.FindById(id);
        }

        public async Task<List<T>> Where(Expression<Func<T, bool>> expression)
        {
            return await repository.Where(expression);
        }

        public async Task<T> Save(T entity)
        {
            return await repository.Add(entity);
        }

        public async Task<T> Update(T entity)
        {
            return await repository.Update(entity);
        }

        public async Task Delete(T entity)
        {
            await repository.Delete(entity);
        }
    }
}
