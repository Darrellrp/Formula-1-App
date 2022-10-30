using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_App.Models;
using Formula_1_App.Repositories;
using Formula_1_App.Datasources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Formula_1_App.Caching;
using System.Runtime.InteropServices;

namespace Formula_1_App.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IDatasourceAdapter<T> _datasource;
        private readonly IDistributedCachingService _cache;
        private readonly RedisMultiplexerCachingService _cachingService;

        public BaseRepository(IDatasourceAdapter<T> datasource, IDistributedCachingService cache, RedisMultiplexerCachingService cachingService)
        {
            _datasource = datasource;
            _cache = cache;
            _cachingService = cachingService;
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
            var records = await _cachingService.GetAll<T>();

            if (records != null)
            {
                return records;
            }

            records = await _datasource.GetAll();

            if(records == null || !records.Any())
            {
                return new List<T>();
            }

            await _cachingService.AddMany(records);
            return records;
        }

        public async Task<IEnumerable<T>> GetPaginated(int page, int limit = 100)
        {
            var records = await _cachingService.GetPaginated<T>(page, limit);

            if (records != null && records.Any())
            {
                return records;
            }

            records = await _datasource.GetPaginated(page, limit);

            if (records == null || !records.Any())
            {
                return new List<T>();
            }

            await _cachingService.AddMany(records);
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

            await _cachingService.Add(newRecord);
            return newRecord;
        }

        public async Task<IEnumerable<T>> AddMany(IEnumerable<T> entities)
        {
            var newRecords = await _datasource.AddMany(entities);

            if(newRecords == null || !newRecords.Any())
            {
                throw new Exception("Failed to create new records");
            }

            await _cachingService.AddMany(newRecords);
            return newRecords;
        }

        public async Task<T> Update(T entity)
        {
            var updatedRecord = await _datasource.Update(entity);

            if(updatedRecord == null)
            {
                throw new Exception("Failed to create new record");
            }

            if(updatedRecord.Id == null)
            {
                throw new Exception("Failed to create a ID for the new record");
            }

            await _cachingService.Update(updatedRecord);
            return updatedRecord;
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> expression)
        {
            var records = await _cachingService.Where(expression.Compile());

            if(records != null && records.Any())
            {
                return records;
            }

            return await _datasource.Where(expression);
        }

        public async Task<T> Delete(T entity)
        {
            var deletedRecord = await _datasource.Delete(entity);
            await _cachingService.Delete(entity);

            return deletedRecord;
        }
    }
}
