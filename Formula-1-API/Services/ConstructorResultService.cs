using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class ConstructorResultService : IService<ConstructorResult>
    {
        private readonly BaseService<ConstructorResult> service;

        public ConstructorResultService(IRepository<ConstructorResult> _repository)
        {
            this.service = new BaseService<ConstructorResult>(_repository);
        }

        public async Task<ConstructorResult> Save(ConstructorResult entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(ConstructorResult entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<ConstructorResult> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<ConstructorResult>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<ConstructorResult> Update(ConstructorResult entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<ConstructorResult>> Where(Expression<Func<ConstructorResult, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
