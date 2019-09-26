using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class LapTimeService : IService<LapTime>
    {
        private readonly BaseService<LapTime> service;

        public LapTimeService(IRepository<LapTime> _repository)
        {
            this.service = new BaseService<LapTime>(_repository);
        }

        public async Task<LapTime> Save(LapTime entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(LapTime entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<LapTime> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<LapTime>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<LapTime> Update(LapTime entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<LapTime>> Where(Expression<Func<LapTime, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
