using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class ConstructorService : IService<Constructor>
    {
        private readonly BaseService<Constructor> service;

        public ConstructorService(IRepository<Constructor> _repository)
        {
            this.service = new BaseService<Constructor>(_repository);
        }

        public async Task<Constructor> Save(Constructor entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(Constructor entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<Constructor> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<Constructor>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<Constructor> Update(Constructor entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<Constructor>> Where(Expression<Func<Constructor, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
