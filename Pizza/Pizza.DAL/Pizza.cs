using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Pizza.DAL
{
    public class Pizza
    {
        public ObjectId Id { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<PizzaContent> Contents { get; set; }
    }
}
