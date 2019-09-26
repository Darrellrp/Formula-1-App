using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFConstructorResultRepository : IRepository<ConstructorResult>
    {
        private readonly EntityFrameworkRepository<ConstructorResult> repository;

        public EFConstructorResultRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<ConstructorResult>(dbContext);
        }        

        public async Task<ConstructorResult> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<ConstructorResult>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<ConstructorResult> Add(ConstructorResult entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<ConstructorResult> Update(ConstructorResult entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<ConstructorResult>> Where(Expression<Func<ConstructorResult, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(ConstructorResult entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
