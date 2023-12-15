using System.Linq.Expressions;
using Formula_1_API.Models;
using Formula_1_API.Datasources;
using Formula_1_API.Caching;
using Formula_1_API.Factories;

namespace Formula_1_API.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IDatasourceAdapter<T> _datasource;
        private readonly IMultiplexerCachingService _cache;
        private readonly string _collectionLabel = string.Empty;

        public BaseRepository(IDatasourceAdapter<T> datasource, IMultiplexerCachingService cache, EntityCollectionLabelFactory keyFactory)
        {
            _datasource = datasource;
            _cache = cache;
            _collectionLabel = keyFactory.CreateSingleLabel<T>();
        }

        public async Task<DbResult<T>?> FindById(int id)
        {
            var record = await _cache.FindById<T>(id);

            if (record != null)
            {
                return new DbResult<T>(_collectionLabel, record);
            }

            record = await _datasource.FindById(id);

            if (record != null)
            {
                await _cache.Add(record);
                return new DbResult<T>(_collectionLabel, record);
            }

            return null;
        }

        public async Task<DbResult<T>> GetAll()
        {
            var cachedRecords = await _cache.GetAll<T>();
            var dbRecords = await _datasource.GetAll();

            if (cachedRecords != null && cachedRecords.SequenceEqual(dbRecords))
            {
                return new DbResult<T>(_collectionLabel, cachedRecords);
            }

            await LoadNewDataInCache(dbRecords);
            return new DbResult<T>(_collectionLabel, dbRecords);
        }

        public async Task<DbResult<T>> GetPaginated(int page, int limit = 100)
        {
            var cachedRecords = await _cache.GetPaginated<T>(page, limit);
            var dbRecords = await _datasource.GetPaginated(page, limit);

            if (cachedRecords != null && cachedRecords.SequenceEqual(dbRecords))
            {
                return new DbResult<T>(_collectionLabel, cachedRecords);
            }

            await LoadNewDataInCache(dbRecords);
            return new DbResult<T>(_collectionLabel, dbRecords);
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

        public async Task<DbResult<T>> AddMany(IEnumerable<T> entities)
        {
            var newRecords = await _datasource.AddMany(entities);

            if (newRecords == null || !newRecords.Any())
            {
                throw new Exception("Failed to create new records");
            }

            await _cache.AddMany(newRecords);
            return new DbResult<T>(_collectionLabel, newRecords);
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

        public async Task<DbResult<T>> Where(Expression<Func<T, bool>> expression)
        {
            var cachedRecords = await _cache.Where(expression.Compile());

            if (cachedRecords != null && cachedRecords.Any())
            {
                return new DbResult<T>(_collectionLabel, cachedRecords);
            }

            var records = await _datasource.Where(expression);
            return new DbResult<T>(_collectionLabel, records);
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
