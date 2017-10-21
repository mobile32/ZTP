using MongoDB.Bson;
using System.Collections.Generic;
using PizzaStore.DAL;

namespace PizzaStore.BLL.Interfaces
{
    public interface IPizzaService
    {
        IEnumerable<DAL.Pizza> GetAll();
        void InsertPizza(DAL.Pizza pizza);
        void DeletePizza(ObjectId id);
        Pizza GetByLanguage(ObjectId id, string language);
    }
}