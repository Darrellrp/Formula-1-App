using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Hubs;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Formula_1_API.Repositories.Interfaces;
using Formula_1_API.Services.Interfaces;
using Formula_1_API.Subjects;
using Formula_1_API.Subjects.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Formula_1_API.Services
{
    public class CircuitService : IService<Circuit>
    {
        protected readonly IRepository<Circuit> repository;
        protected readonly ISubject<Circuit> subject;

        public CircuitService(IRepository<Circuit> repository, ISubject<Circuit> subject)
        {
            this.repository = repository;
            this.subject = subject;
        }

        public async Task<List<Circuit>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<List<Circuit>> GetPaginated(int page, int limit = 100)
        {
            return await repository.GetPaginated(page, limit);
        }

        public async Task<Circuit> FindById(int id)
        {
            return await repository.FindById(id);
        }

        public async Task<List<Circuit>> Where(Expression<Func<Circuit, bool>> expression)
        {
            return await repository.Where(expression);
        }

        public async Task<Circuit> Save(Circuit entity)
        {
            var newEntity = await repository.Add(entity);
            await subject.NotifyAdd(newEntity);

            return newEntity;
        }

        public async Task<List<Circuit>> Save(List<Circuit> entities)
        {
            var newEntities = await repository.AddMany(entities);
            await subject.NotifyAddMany(newEntities);

            return newEntities;
        }

        public async Task<Circuit> Update(Circuit entity)
        {
            var updatedEntity = await repository.Update(entity);
            await subject.NotifyUpdate(updatedEntity);

            return updatedEntity;
        }

        // TODO: Return ID
        public async Task Delete(Circuit entity)
        {
            var deletedEntity = await repository.Delete(entity);
            await subject.NotifyRemove(deletedEntity);
        }
    }
}