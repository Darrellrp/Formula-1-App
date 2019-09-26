using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class PitStopService : IService<PitStop>
    {
        private readonly BaseService<PitStop> service;

        public PitStopService(IRepository<PitStop> _repository)
        {
            this.service = new BaseService<PitStop>(_repository);
        }

        public async Task<PitStop> Save(PitStop entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(PitStop entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<PitStop> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<PitStop>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<PitStop> Update(PitStop entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<PitStop>> Where(Expression<Func<PitStop, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
