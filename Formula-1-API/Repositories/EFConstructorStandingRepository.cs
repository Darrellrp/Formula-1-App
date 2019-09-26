using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFConstructorStandingRepository : IRepository<ConstructorStanding>
    {
        private readonly EntityFrameworkRepository<ConstructorStanding> repository;

        public EFConstructorStandingRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<ConstructorStanding>(dbContext);
        }        

        public async Task<ConstructorStanding> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<ConstructorStanding>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<ConstructorStanding> Add(ConstructorStanding entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<ConstructorStanding> Update(ConstructorStanding entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<ConstructorStanding>> Where(Expression<Func<ConstructorStanding, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(ConstructorStanding entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
