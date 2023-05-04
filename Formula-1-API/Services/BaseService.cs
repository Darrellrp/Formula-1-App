﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Subjects;
using Formula_1_API.Services;
using Formula_1_API.Datasources;
using Formula_1_API.Repositories;

namespace Formula_1_API.Services
{
    public class BaseService<T> : IService<T> where T : class, IEntity
    {
        protected readonly IRepository<T> repository;
        protected readonly ISubject<T> subject;

        public BaseService(IRepository<T> _repository, ISubject<T> subject)
        {
            this.repository = _repository;
            this.subject = subject;
        }

        public async Task<DbResult<T>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<DbResult<T>> GetPaginated(int page, int limit = 100)
        {
            return await repository.GetPaginated(page, limit);
        }

        public async Task<DbResult<T>?> FindById(int id)
        {
            return await repository.FindById(id);
        }

        public async Task<DbResult<T>> Where(Expression<Func<T, bool>> expression)
        {
            return await repository.Where(expression);
        }

        public async Task<T> Save(T entity)
        {
            var newEntity = await repository.Add(entity);
            await subject.NotifyAdd(newEntity);

            return newEntity;
        }

        public async Task<DbResult<T>> Save(IEnumerable<T> entities)
        {
            var newEntities = await repository.AddMany(entities);
            await subject.NotifyAddMany(newEntities.Collection);

            return newEntities;
        }

        public async Task<T> Update(int id, T entity)
        {
            if (!entity.Id.HasValue)
            {
                entity.Id = id;
            }

            var updatedEntity = await repository.Update(entity);
            await subject.NotifyUpdate(updatedEntity);

            return updatedEntity;
        }

        // TODO: Return ID
        public async Task Delete(T entity)
        {
            var deletedEntity = await repository.Delete(entity);
            await subject.NotifyRemove(deletedEntity);
        }
    }
}
