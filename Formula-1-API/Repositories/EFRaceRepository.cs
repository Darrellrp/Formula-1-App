using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFRaceRepository : IRepository<Race>
    {
        private readonly EntityFrameworkRepository<Race> repository;

        public EFRaceRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<Race>(dbContext);
        }        

        public async Task<Race> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<Race>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<Race> Add(Race entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<Race> Update(Race entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<Race>> Where(Expression<Func<Race, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(Race entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
