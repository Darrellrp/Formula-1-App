using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_App.Models;
using Formula_1_App.Repositories;
using Formula_1_App.Datasources;
using Microsoft.EntityFrameworkCore;
using Formula_1_App.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Formula_1_App.Caching;

namespace Formula_1_App.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IDatasourceAdapter<T> _datasource;
        private readonly ICachingService _cache;

        public BaseRepository(IDatasourceAdapter<T> datasource, ICachingService cache)
        {
            _datasource = datasource;
            _cache = cache;
        }        

        public async Task<T?> FindById(int id)
        {
            var record = await _cache.GetRecordAsync<T>(id.ToString());

            if(record != null)
            {
                return record;
            }

            record = await _datasource.FindById(id);

            if (record == null)
            {
                return null;
            }

            await _cache.SetRecordAsync<T>(id.ToString(), record);
            return record;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var records = await _cache.GetRecordsAsync<T>();

            if(records != null)
            {
                return records;
            }

            records = await _datasource.GetAll();

            if(records == null)
            {
                return new List<T>();
            }

            await _cache.SetRecordsAsync<T>(records);
            return records;
        }

        public async Task<IEnumerable<T>> GetPaginated(int page, int limit = 100)
        {
            var records = await _cache.GetRecordsAsync<T>();

            if(records != null)
            {
                return records;
            }

            records = await _datasource.GetPaginated(page, limit);

            if(records == null)
            {
                return new List<T>();
            }

            return records;
        }

        public async Task<T> Add(T entity)
        {
            var newRecord = await _datasource.Add(entity);

            if(newRecord == null)
            {
                throw new Exception("Failed to create new record");
            }

            if (newRecord.Id == null)
            {
                throw new Exception("Failed to create a ID for the new record");
            }

            await _cache.SetRecordAsync($"{newRecord.Id}", newRecord);
            return newRecord;
        }

        public async Task<IEnumerable<T>> AddMany(IEnumerable<T> entities)
        {
            return await _datasource.AddMany(entities);
        }

        public async Task<T> Update(T entity)
        {
            return await _datasource.Update(entity);
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> expression)
        {
            return await _datasource.Where(expression);
        }

        public async Task<T> Delete(T entity)
        {
            return await _datasource.Delete(entity);
        }
    }
}
