using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class QualificationService : IService<Qualification>
    {
        private readonly BaseService<Qualification> service;

        public QualificationService(IRepository<Qualification> _repository)
        {
            this.service = new BaseService<Qualification>(_repository);
        }

        public async Task<Qualification> Save(Qualification entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(Qualification entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<Qualification> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<Qualification>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<Qualification> Update(Qualification entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<Qualification>> Where(Expression<Func<Qualification, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
