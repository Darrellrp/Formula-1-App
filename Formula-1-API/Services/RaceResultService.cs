using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class RaceResultService : IService<RaceResult>
    {
        private readonly BaseService<RaceResult> service;

        public RaceResultService(IRepository<RaceResult> _repository)
        {
            this.service = new BaseService<RaceResult>(_repository);
        }

        public async Task<RaceResult> Save(RaceResult entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(RaceResult entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<RaceResult> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<RaceResult>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<RaceResult> Update(RaceResult entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<RaceResult>> Where(Expression<Func<RaceResult, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
