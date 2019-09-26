using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Formula_1_API.Repositories
{
    public class EFConstructorRepository : IRepository<Constructor>
    {
        private readonly EntityFrameworkRepository<Constructor> repository;

        public EFConstructorRepository(DbContext dbContext)
        {
            this.repository = new EntityFrameworkRepository<Constructor>(dbContext);
        }        

        public async Task<Constructor> FindById(int id)
        {
            return await this.repository.FindById(id);
        }

        public async Task<List<Constructor>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<Constructor> Add(Constructor entity)
        {
            return await this.repository.Add(entity);
        }

        public async Task<Constructor> Update(Constructor entity)
        {
            return await this.repository.Update(entity);
        }

        public async Task<List<Constructor>> Where(Expression<Func<Constructor, bool>> expression)
        {
            return await this.repository.Where(expression);
        }

        public async Task Delete(Constructor entity)
        {
            await this.repository.Delete(entity);
        }
    }
}
