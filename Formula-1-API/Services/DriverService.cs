using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class DriverService : IService<Driver>
    {
        private readonly BaseService<Driver> service;

        public DriverService(IRepository<Driver> _repository)
        {
            this.service = new BaseService<Driver>(_repository);
        }

        public async Task<Driver> Save(Driver entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(Driver entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<Driver> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<Driver>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<Driver> Update(Driver entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<Driver>> Where(Expression<Func<Driver, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
