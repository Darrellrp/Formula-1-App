using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class SeasonService : IService<Season>
    {
        private readonly BaseService<Season> service;

        public SeasonService(IRepository<Season> _repository)
        {
            this.service = new BaseService<Season>(_repository);
        }

        public async Task<Season> Save(Season entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(Season entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<Season> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<Season>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<Season> Update(Season entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<Season>> Where(Expression<Func<Season, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
