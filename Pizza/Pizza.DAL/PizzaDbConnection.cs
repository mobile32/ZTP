using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.DAL
{
    public class PizzaDbConnection
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public PizzaDbConnection()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("pizzaStore");
        }

        public IMongoCollection<T> GetCollection<T>(string name) where T: class
        {
            return _database.GetCollection<T>(name);
        }
    }
}
