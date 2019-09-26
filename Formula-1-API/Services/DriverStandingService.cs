using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class DriverStandingService : IService<DriverStanding>
    {
        private readonly BaseService<DriverStanding> service;

        public DriverStandingService(IRepository<DriverStanding> _repository)
        {
            this.service = new BaseService<DriverStanding>(_repository);
        }

        public async Task<DriverStanding> Save(DriverStanding entity)
        {
            return await this.service.Save(entity);
        }

        public async Task Delete(DriverStanding entity)
        {
            await this.service.Delete(entity);
        }

        public async Task<DriverStanding> FindById(int id)
        {
            return await this.service.FindById(id);
        }

        public async Task<List<DriverStanding>> GetAll()
        {
            return await this.service.GetAll();
        }

        public async Task<DriverStanding> Update(DriverStanding entity)
        {
            return await this.service.Update(entity);
        }

        public async Task<List<DriverStanding>> Where(Expression<Func<DriverStanding, bool>> expression)
        {
            return await this.service.Where(expression);
        }
    }
}
