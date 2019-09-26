using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFDriverRepository : IRepository<Driver>
    {
        private readonly EntityFrameworkRepository<Driver> repository;

        public EFDriverRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<Driver>(dbContext);
        }        

        public async Task<Driver> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<Driver>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<Driver> Add(Driver entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<Driver> Update(Driver entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<Driver>> Where(Expression<Func<Driver, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(Driver entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
