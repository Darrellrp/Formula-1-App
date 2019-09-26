using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFSeasonRepository : IRepository<Season>
    {
        private readonly EntityFrameworkRepository<Season> repository;

        public EFSeasonRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<Season>(dbContext);
        }        

        public async Task<Season> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<Season>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<Season> Add(Season entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<Season> Update(Season entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<Season>> Where(Expression<Func<Season, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(Season entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
