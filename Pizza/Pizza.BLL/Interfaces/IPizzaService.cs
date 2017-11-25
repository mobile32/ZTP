using MongoDB.Bson;
using System.Collections.Generic;
using PizzaStore.BLL.DTO;
using PizzaStore.DAL;

namespace PizzaStore.BLL.Interfaces
{
    public interface IPizzaService
    {
        IEnumerable<DAL.Pizza> GetAll();
        void InsertPizza(DAL.Pizza pizza);
        void DeletePizza(ObjectId id);
        PizzaDTO GetByLanguage(ObjectId id, string language);
    }
}