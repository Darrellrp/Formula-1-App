using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Formula_1_App.Extensions
{
    public static class RedisCachingExtension
    {
        public static async Task SetRecordAsync<T>(
            this IDistributedCache cache,
            string recordId,
            T data, 
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? slidingExpireTime = null
        )
        {
            var options = new DistributedCacheEntryOptions { 
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
                SlidingExpiration = slidingExpireTime
            };


            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }

        public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);

            if (jsonData == null)
            {
                return default;
            }

            var stream = new MemoryStream(Encoding.ASCII.GetBytes(jsonData));

            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}
