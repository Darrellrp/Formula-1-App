using System;
namespace Formula_1_API.Models
{
    public class Response<T> where T : class, IEntity
    {
        public Meta<T> Meta { get; set; }
        public Payload Payload { get; set; }

        public Response(dynamic data)
        {
            Meta = new Meta<T>();
            Payload = new Payload(data);
        }
    }

    public class Meta<T>
    {
        public string Type { get; set; } = typeof(T).Name;
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

