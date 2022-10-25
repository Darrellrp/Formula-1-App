﻿using Microsoft.Extensions.Caching.Distributed;

namespace Formula_1_App.Caching
{
    public interface ICachingService
    {
        Task<IEnumerable<T>?> GetRecordsAsync<T>();

        Task<T?> GetRecordAsync<T>(string recordId);

        Task SetRecordsAsync<T>(
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
