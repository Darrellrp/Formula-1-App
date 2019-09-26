using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFPitStopRepository : IRepository<PitStop>
    {
        private readonly EntityFrameworkRepository<PitStop> repository;

        public EFPitStopRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<PitStop>(dbContext);
        }        

        public async Task<PitStop> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<PitStop>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<PitStop> Add(PitStop entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<PitStop> Update(PitStop entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<PitStop>> Where(Expression<Func<PitStop, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(PitStop entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
