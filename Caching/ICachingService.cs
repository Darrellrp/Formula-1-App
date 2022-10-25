using Microsoft.Extensions.Caching.Distributed;

namespace Formula_1_App.Caching
{
    public interface ICachingService
    {
        Task SetRecordAsync<T>(
            string recordId,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? slidingExpireTime = null
        );

        Task<T?> GetRecordAsync<T>(string recordId);
    }
}
