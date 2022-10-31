using Formula_1_App.Models;
using MongoDB.Bson;
using SharpCompress.Common;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;

namespace Formula_1_App.Caching
{
    public class RedisMultiplexerCachingService : IMultiplexerCachingService
    {
        private IDatabase _database { get; set; }

        public RedisMultiplexerCachingService(IConnectionMultiplexer multiplexer)
        {
            _database = multiplexer.GetDatabase();
        }

        public async Task<T?> FindById<T>(int id) where T : class, IEntity
        {
            var key = GenerateKey<T>();
            long index;

            if (!long.TryParse(id.ToString(), out index))
            {
                throw new Exception($"{typeof(T).Name} ID cannot be converted to long");
            }

            var record = await _database.HashGetAsync(key, index);

            if(record.ToString().Equals(String.Empty))
            {
                return null;
            }

            return Deserialize<T>(record.ToString());
        }

        public async Task<IEnumerable<T>> Where<T>(Func<T, bool> expression) where T : class, IEntity
        {
            var key = GenerateKey<T>();
            var recordArray = await _database.HashGetAllAsync(key);
            var records = recordArray.Select(x => Deserialize<T>(x.ToString())).ToList();
            var filteredRecords = records.Where(expression);

            return OrderById(filteredRecords);
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class, IEntity
        {
            var key = GenerateKey<T>();

            var recordArray = await _database.HashGetAllAsync(key);

            if(recordArray == null)
            {
                throw new Exception($"{typeof(T).Name} is null");
            }

            var records = recordArray.Select(x => Deserialize<T>(x.ToString()));

            return OrderById(records);
        }

        public async Task<IEnumerable<T>> GetPaginated<T>(int page, int limit = 100) where T : class, IEntity
        {
            var key = GenerateKey<T>();
            
            var recordArray = await _database.HashGetAllAsync(key);

            if(recordArray == null || !recordArray.Any())
            {
                return new List<T>();
            }

            var records = recordArray.Select(x => Deserialize<T>(x.Value.ToString()));

            return OrderById(records).Take(limit);
        }

        public async Task Add<T>(T entity) where T : class, IEntity
        {
            var key = GenerateKey<T>();
            var value = Serialize(entity);

            if(!entity.Id.HasValue)
            {
                throw new Exception($"{typeof(T).Name} does not have an ID");
            }

            if(value == null)
            {
                throw new Exception($"Failed to serialize {typeof(T).Name}");
            }

            var newEntry = new HashEntry[] { new HashEntry(entity.Id, value) };
            await _database.HashSetAsync(key, newEntry);
        }

        public async Task AddMany<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            var key = GenerateKey<T>();

            if (!entities.All(x => x.Id.HasValue))
            {
                throw new Exception($"{typeof(T).Name} does not have an ID");
            }

            var newEntries = entities.Select(x => new HashEntry(x.Id, Serialize(x))).ToArray();
            await _database.HashSetAsync(key, newEntries);
        }

        public async Task<T> Update<T>(T entity) where T : class, IEntity
        {
            var key = GenerateKey<T>();
            var value = Serialize(entity);
            var entry = new HashEntry[] { new HashEntry(entity.Id, value) };

            await _database.HashSetAsync(key, entry);
            return entity;
        }

        public async Task<T> Delete<T>(T entity) where T : class, IEntity
        {
            var key = GenerateKey<T>();
            await _database.HashDeleteAsync(key, entity.Id);
            return entity;
        }

        public async Task DeleteAll<T>() where T : class, IEntity
        {
            var key = GenerateKey<T>();
            await _database.KeyDeleteAsync(key);
        }

        private IEnumerable<T> OrderById<T>(IEnumerable<T> records) where T : class, IEntity
        {
            return records.OrderBy(x => x.Id);
        }

        private string Serialize<T>(T entity)
        {
            return JsonSerializer.Serialize(entity);
        }

        private T Deserialize<T>(string json)
        {
            var deserializedObject = JsonSerializer.Deserialize<T>(json);

            if(deserializedObject ==  null)
            {
                throw new JsonException($"Failed to deserialized {typeof(T).Name}");
            }

            return deserializedObject;
        }

        private string GenerateKey<T>()
        {
            return typeof(T).Name;
        }
    }
}
