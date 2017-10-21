using System.Collections.Generic;
using System.Globalization;
using MongoDB.Bson;
using PizzaStore.BLL.Interfaces;
using PizzaStore.DAL;
using PizzaStore.DAL.Interfaces;

namespace PizzaStore.BLL.Implementations
{
    public class PizzaService : IPizzaService
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

        public Pizza GetByLanguage(ObjectId id, string language)
        {
            language = language ?? CultureInfo.CurrentCulture.Name;
            var translator = new TranslatorBuilder()
                .AddLanguage(language)
                .AddLanguage("en")
                .AddLanguage("pl")
                .AddLanguage("")
                .Build();

            return translator.GetTranslation(_pizzaRepository.GetById(id));
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