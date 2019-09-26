using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFResultStatusRepository : IRepository<ResultStatus>
    {
        private readonly EntityFrameworkRepository<ResultStatus> repository;

        public EFResultStatusRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<ResultStatus>(dbContext);
        }        

        public async Task<ResultStatus> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<ResultStatus>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<ResultStatus> Add(ResultStatus entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<ResultStatus> Update(ResultStatus entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<ResultStatus>> Where(Expression<Func<ResultStatus, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(ResultStatus entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
