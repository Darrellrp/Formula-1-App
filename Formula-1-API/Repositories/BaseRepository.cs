using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Formula_1_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IIdentifier
    {
        private readonly IDatasourceAdapter<T> adapter;

        public BaseRepository(IDatasourceAdapter<T> adapter)
        {
            this.adapter = adapter;
        }        

        public async Task<T> FindById(int id)
        {
            return await adapter.FindById(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await adapter.GetAll();
        }

        public async Task<T> Add(T entity)
        {
            return await adapter.Add(entity);
        }

        public async Task<List<T>> AddMany(List<T> entities)
        {
            return await adapter.AddMany(entities);
        }

        public async Task<T> Update(T entity)
        {
            return await adapter.Update(entity);
        }

        public async Task<List<T>> Where(Expression<Func<T, bool>> expression)
        {
            return await adapter.Where(expression);
        }

        public async Task<T> Delete(T entity)
        {
            return await adapter.Delete(entity);
        }
    }
}
