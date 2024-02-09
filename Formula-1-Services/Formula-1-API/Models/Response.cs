using System;

namespace Formula_1_API.Models
{
    public class Response<T> where T : class, IEntity
    {
        public Meta<T> Meta { get; set; }
        public Payload Payload { get; set; }

        public Response(string collectionLabel, T record)
        {
            Meta = new()
            {
                CollectionLabel = collectionLabel.AddSpacesToPascalCase(),
                CollectionKey = collectionLabel.ToLower()
            };
            Payload = new(record);
        }

        public Response(string collectionLabel, IEnumerable<T> collection)
        {
            Meta = new()
            {
                CollectionLabel = collectionLabel.AddSpacesToPascalCase(),
                CollectionKey = collectionLabel.ToLower()
            };
            Payload = new(collection);
        }
    }

    public class Meta<T>
    {
        public string EntityLabel { get; init; } = typeof(T).Name.AddSpacesToPascalCase();
        public string CollectionLabel { get; set; } = string.Empty;
        public string CollectionKey { get; set; } = string.Empty;
    }

    public class Payload
    {
        public dynamic Data { get; set; }

        public Payload(dynamic data)
        {
            Data = data;
        }
    }
}

