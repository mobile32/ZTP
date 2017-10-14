using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PizzaStore.DAL
{
    public class Pizza
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<PizzaContent> Contents { get; set; }
    }
}
