using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Formula_1_API.Models;
using Formula_1_API.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Formula_1_API.Repositories.Adapters
{
    public class MongoAdapter<T> : IDatasourceAdapter<T> where T : class, IIdentifier
    {
        protected readonly IMongoClient client;
        protected readonly IMongoDatabase database;

        public MongoAdapter()
        {
            // TODO: Add to connection strings
            var connectionString = "mongodb://localhost:27017";
            this.client = new MongoClient(connectionString);

            // TODO: Add to connection strings
            this.database = client.GetDatabase("Formula1App_MongoDB");
        }

        public async Task<T> FindById(int id)
        {
            var collection = database.GetCollection<T>(typeof(T).Name.ToLower());
            var filter = Builders<T>.Filter.Eq(e => e.Id, id);
            var entity = await collection.FindSync(filter).ToListAsync();
            return entity[0];
        }

        public async Task<List<T>> Where(Expression<Func<T, bool>> expression)
        {
            var collection = database.GetCollection<T>(typeof(T).Name.ToLower());
            var filter = Builders<T>.Filter.Where(expression);
            var entities = await collection.FindAsync(filter);

            return await entities.ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            var collection = database.GetCollection<T>(typeof(T).Name.ToLower());
            var filter = Builders<T>.Filter.Empty;
            var entities = await collection.Find<T>(filter).ToListAsync();

            return entities;
        }

        public async Task<T> Add(T entity)
        {
            var collection = database.GetCollection<T>(typeof(T).Name.ToLower());
            //var filter = Builders<T>.Update.Inc(d => d.Id, 1);
            //await collection.FindOneAndUpdateAsync(entity, filter);
            await collection.InsertOneAsync(entity);            

            return entity;
        }

        public async Task<List<T>> AddMany(List<T> entities)
        {
            var collection = database.GetCollection<T>(typeof(T).Name.ToLower());
            //var filter = Builders<T>.Update.Inc(d => d.Id, 1);
            //await collection.FindOneAndUpdateAsync(entity, filter);
            await collection.InsertManyAsync(entities);

            return entities;
        }

        public async Task<T> Update(T entity)
        {
            var collection = database.GetCollection<T>(typeof(T).Name.ToLower());
            await collection.ReplaceOneAsync<T>(e => e.Id == entity.Id, entity);

            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            var collection = database.GetCollection<T>(typeof(T).Name.ToLower());
            var filter = Builders<T>.Filter.Eq(e => e.Id, entity.Id);
            await collection.DeleteOneAsync(filter);

            return entity;
        }
        
    }
}
