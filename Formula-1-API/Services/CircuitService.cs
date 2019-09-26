using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class CircuitService : IService<Circuit>
    {
        private readonly BaseService<Circuit> service;

        public CircuitService(IRepository<Circuit> _repository)
        {
            this.service = new BaseService<Circuit>(_repository);
        }

        public async Task<Circuit> Save(Circuit entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(Circuit entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<Circuit> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<Circuit>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<Circuit> Update(Circuit entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<Circuit>> Where(Expression<Func<Circuit, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
