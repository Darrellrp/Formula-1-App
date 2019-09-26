using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class RaceService : IService<Race>
    {
        private readonly BaseService<Race> service;

        public RaceService(IRepository<Race> _repository)
        {
            this.service = new BaseService<Race>(_repository);
        }

        public async Task<Race> Save(Race entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(Race entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<Race> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<Race>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<Race> Update(Race entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<Race>> Where(Expression<Func<Race, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
