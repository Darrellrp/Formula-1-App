using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula_1_API.Models
{
    public class DbResult<T> where T : class, IEntity
    {
        public string CollectionLabel { get; init; } = string.Empty;
        public T Record { get; init; } = null!;
        public IEnumerable<T> Collection { get; init; } = null!;

        public bool HasCollection { get; init; } = default;

        public DbResult(string collectionKey, T record)
        {
            CollectionLabel = collectionKey;
            Record = record;
            HasCollection = false;
        }

        public DbResult(string collectionKey, IEnumerable<T> records)
        {
            CollectionLabel = collectionKey;
            Collection = records;
            HasCollection = true;
        }
    }
}