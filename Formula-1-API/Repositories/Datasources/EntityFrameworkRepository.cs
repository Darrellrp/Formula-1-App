using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
//using Formula_1_API.Context;
using Formula_1_API.Models;

namespace Formula_1_API.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public EntityFrameworkRepository(DbContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        public async Task<T>FindById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> Where(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync(); 
            return entity;
        }

        public async Task<T> Update(T entity) 
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
