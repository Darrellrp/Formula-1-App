using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Formula_1_App.Caching
{
    public class RedisCachingService : ICachingService
    {
        private readonly string _recordIdAll = "ALL";

        public IDistributedCache _cache { get; set; }

        public RedisCachingService(IDistributedCache cache) 
        {
            _cache = cache;   
        }

        public async Task<T?> GetRecordAsync<T>(string id)
        {
            var recordId = await GenerateRecordId<T>(id);
            var jsonData = await _cache.GetStringAsync(recordId);

            if (jsonData == null)
            {
                return default;
            }

            var stream = new MemoryStream(Encoding.ASCII.GetBytes(jsonData));

            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public async Task<IEnumerable<T>?> GetRecordsAsync<T>()
        {
            var recordsId = await GenerateRecordId<T>(_recordIdAll);
            var jsonData = await _cache.GetStringAsync(recordsId);

            if (jsonData == null)
            {
                return null;
            }

            var stream = new MemoryStream(Encoding.ASCII.GetBytes(jsonData));

            return await JsonSerializer.DeserializeAsync<IEnumerable<T>>(stream);
        }

        public async Task SetRecordsAsync<T>(
            IEnumerable<T> data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? slidingExpireTime = null
        )
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
                SlidingExpiration = slidingExpireTime
            };
            var recordId = await GenerateRecordId<T>(_recordIdAll);

            var jsonData = JsonSerializer.Serialize(data);
            await _cache.SetStringAsync(recordId, jsonData, options);
        }

        public async Task SetRecordAsync<T>(
            string id,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? slidingExpireTime = null
        )
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
                SlidingExpiration = slidingExpireTime
            };
            var recordId = await GenerateRecordId<T>(id);

            var jsonData = JsonSerializer.Serialize(data);
            await _cache.SetStringAsync(recordId, jsonData, options);
        }

        private async Task<string> GenerateRecordId<T>(string id)
        {
            return await Task.FromResult($"{typeof(T).Name}_{id}");
        }
    }
}
