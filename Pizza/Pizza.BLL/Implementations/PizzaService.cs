using System.Collections.Generic;
using MongoDB.Bson;
using PizzaStore.BLL.Interfaces;
using PizzaStore.DAL;
using PizzaStore.DAL.Interfaces;

namespace PizzaStore.BLL.Implementations
{
    public class PizzaService: IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public void DeletePizza(ObjectId id)
        {
            _pizzaRepository.Remove(id);

        }

        public IEnumerable<DAL.Pizza> GetAll()
        {
            return _pizzaRepository.GetByQuery(x => true);
        }

        public void InsertPizza(Pizza pizza)
        {
            _pizzaRepository.Add(pizza);
        }
    }
}