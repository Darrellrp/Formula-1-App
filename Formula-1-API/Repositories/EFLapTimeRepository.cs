using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFLapTimeRepository : IRepository<LapTime>
    {
        private readonly EntityFrameworkRepository<LapTime> repository;

        public EFLapTimeRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<LapTime>(dbContext);
        }        

        public async Task<LapTime> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<LapTime>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<LapTime> Add(LapTime entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<LapTime> Update(LapTime entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<LapTime>> Where(Expression<Func<LapTime, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(LapTime entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
