using Microsoft.Extensions.Caching.Distributed;

namespace Formula_1_API.Caching
{
    public interface IDistributedCachingService
    {
        Task<IEnumerable<T>?> GetCollectionAsync<T>();

        Task<T?> GetRecordAsync<T>(string recordId);

        Task SetCollectionAsync<T>(
            IEnumerable<T> data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? slidingExpireTime = null
        );

        Task SetRecordAsync<T>(
            string recordId,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? slidingExpireTime = null
        );
    }
}
