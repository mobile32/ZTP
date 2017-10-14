using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PizzaStore.DAL.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;

namespace PizzaStore.DAL.Implementations
{
    public class PizzaRepository: IPizzaRepository
    {
        private readonly PizzaDbConnection db;

        public IMongoCollection<Pizza> PizzaCollection { get; set; }

        public PizzaRepository(PizzaDbConnection db)
        {
            this.db = db;
            this.PizzaCollection = db.GetCollection<Pizza>("pizza");
        }


        public Pizza GetById(ObjectId id)
        {
            return PizzaCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Pizza> GetByQuery(Expression<Func<Pizza, bool>> predicate)
        {
            return PizzaCollection.Find(predicate).ToList();
        }

        public void Add(Pizza item)
        {
            PizzaCollection.InsertOne(item);
        }

        public void Remove(ObjectId id)
        {
            var filter = Builders<Pizza>.Filter.Where(x=> x.Id == id);
            PizzaCollection.DeleteOne(filter);
        }
    }
}