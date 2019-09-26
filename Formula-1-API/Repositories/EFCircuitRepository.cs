using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFCircuitRepository : IRepository<Circuit>
    {
        private readonly EntityFrameworkRepository<Circuit> repository;

        public EFCircuitRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<Circuit>(dbContext);
        }        

        public async Task<Circuit> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<Circuit>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<Circuit> Add(Circuit entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<Circuit> Update(Circuit entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<Circuit>> Where(Expression<Func<Circuit, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(Circuit entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
