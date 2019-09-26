using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Formula_1_API.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : class
    {
        public MongoRepository() { }

        public Task<T> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Where(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }
        
    }
}
