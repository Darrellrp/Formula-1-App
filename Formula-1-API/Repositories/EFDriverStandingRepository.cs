using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFDriverStandingRepository : IRepository<DriverStanding>
    {
        private readonly EntityFrameworkRepository<DriverStanding> repository;

        public EFDriverStandingRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<DriverStanding>(dbContext);
        }        

        public async Task<DriverStanding> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<DriverStanding>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<DriverStanding> Add(DriverStanding entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<DriverStanding> Update(DriverStanding entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<DriverStanding>> Where(Expression<Func<DriverStanding, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(DriverStanding entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
