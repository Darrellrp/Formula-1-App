using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFQualificationRepository : IRepository<Qualification>
    {
        private readonly EntityFrameworkRepository<Qualification> repository;

        public EFQualificationRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<Qualification>(dbContext);
        }        

        public async Task<Qualification> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<Qualification>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<Qualification> Add(Qualification entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<Qualification> Update(Qualification entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<Qualification>> Where(Expression<Func<Qualification, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(Qualification entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
