﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories;
using Formula_1_API.Datasources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Formula_1_API.Caching;
using System.Runtime.InteropServices;
using DnsClient.Protocol;

namespace Formula_1_API.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IDatasourceAdapter<T> _datasource;
        private readonly IMultiplexerCachingService _cache;

        public BaseRepository(IDatasourceAdapter<T> datasource, IMultiplexerCachingService cache)
        {
            _datasource = datasource;
            _cache = cache;
        }

        public async Task<T?> FindById(int id)
        {
            var record = await _cache.FindById<T>(id);

            if (record != null)
            {
                return record;
            }

            record = await _datasource.FindById(id);

            if (record == null)
            {
                return null;
            }

            await _cache.Add(record);
            return record;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var cachedRecords = await _cache.GetAll<T>();
            var dbRecords = await _datasource.GetAll();

            if (cachedRecords != null && cachedRecords.SequenceEqual(dbRecords))
            {
                return cachedRecords;
            }

            await LoadNewDataInCache(dbRecords);
            return dbRecords;
        }

        public async Task<IEnumerable<T>> GetPaginated(int page, int limit = 100)
        {
            var cachedRecords = await _cache.GetPaginated<T>(page, limit);
            var dbRecords = await _datasource.GetPaginated(page, limit);

            if (cachedRecords != null && cachedRecords.SequenceEqual(dbRecords))
            {
                return cachedRecords;
            }

            await LoadNewDataInCache(dbRecords);
            return dbRecords;
        }

        public async Task<T> Add(T entity)
        {
            var newRecord = await _datasource.Add(entity);

            if (newRecord == null)
            {
                throw new Exception("Failed to create new record");
            }

            if (newRecord.Id == null)
            {
                throw new Exception("Failed to create a ID for the new record");
            }

            await _cache.Add(newRecord);
            return newRecord;
        }

        public async Task<IEnumerable<T>> AddMany(IEnumerable<T> entities)
        {
            var newRecords = await _datasource.AddMany(entities);

            if (newRecords == null || !newRecords.Any())
            {
                throw new Exception("Failed to create new records");
            }

            await _cache.AddMany(newRecords);
            return newRecords;
        }

        public async Task<T> Update(T entity)
        {
            var updatedRecord = await _datasource.Update(entity);

            if (updatedRecord == null)
            {
                throw new Exception("Failed to create new record");
            }

            if (updatedRecord.Id == null)
            {
                throw new Exception("Failed to create a ID for the new record");
            }

            await _cache.Update(updatedRecord);
            return updatedRecord;
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> expression)
        {
            var records = await _cache.Where(expression.Compile());

            if (records != null && records.Any())
            {
                return records;
            }

            return await _datasource.Where(expression);
        }

        public async Task<T> Delete(T entity)
        {
            var deletedRecord = await _datasource.Delete(entity);
            await _cache.Delete(entity);

            return deletedRecord;
        }

        public async Task<int> Count()
        {
            return await _datasource.Count();
        }

        private async Task LoadNewDataInCache(IEnumerable<T> newEntities)
        {
            await _cache.DeleteAll<T>();
            await _cache.AddMany(newEntities);
        }
    }
}