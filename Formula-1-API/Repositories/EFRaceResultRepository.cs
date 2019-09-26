using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFRaceResultRepository : IRepository<RaceResult>
    {
        private readonly EntityFrameworkRepository<RaceResult> repository;

        public EFRaceResultRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<RaceResult>(dbContext);
        }        

        public async Task<RaceResult> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<RaceResult>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<RaceResult> Add(RaceResult entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<RaceResult> Update(RaceResult entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<RaceResult>> Where(Expression<Func<RaceResult, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(RaceResult entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
