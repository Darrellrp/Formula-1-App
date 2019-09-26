using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class ResultStatusService : IService<ResultStatus>
    {
        private readonly BaseService<ResultStatus> service;

        public ResultStatusService(IRepository<ResultStatus> _repository)
        {
            this.service = new BaseService<ResultStatus>(_repository);
        }

        public async Task<ResultStatus> Save(ResultStatus entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(ResultStatus entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<ResultStatus> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<ResultStatus>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<ResultStatus> Update(ResultStatus entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<ResultStatus>> Where(Expression<Func<ResultStatus, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
