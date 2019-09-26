using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class ConstructorStandingService : IService<ConstructorStanding>
    {
        private readonly BaseService<ConstructorStanding> service;

        public ConstructorStandingService(IRepository<ConstructorStanding> _repository)
        {
            this.service = new BaseService<ConstructorStanding>(_repository);
        }

        public async Task<ConstructorStanding> Save(ConstructorStanding entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(ConstructorStanding entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<ConstructorStanding> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<ConstructorStanding>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<ConstructorStanding> Update(ConstructorStanding entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<ConstructorStanding>> Where(Expression<Func<ConstructorStanding, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
