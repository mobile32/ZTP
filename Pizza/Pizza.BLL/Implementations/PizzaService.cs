﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MongoDB.Bson;
using PizzaStore.BLL.DTO;
using PizzaStore.BLL.Interfaces;
using PizzaStore.DAL;
using PizzaStore.DAL.Interfaces;

namespace PizzaStore.BLL.Implementations
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ILanguageSelectorBuilder _builder;

        public PizzaService(IPizzaRepository pizzaRepository, ILanguageSelectorBuilder builder)
        {
            _pizzaRepository = pizzaRepository;
            _builder = builder;
        }

        public void DeletePizza(ObjectId id)
        {
            _pizzaRepository.Remove(id);

        }

        public PizzaDTO GetByLanguage(ObjectId id, string language)
        {
            language = language ?? CultureInfo.CurrentCulture.Name;
            var translator = _builder
                .AddLanguage(language)
                .AddLanguage("en")
                .AddLanguage("pl")
                .Build();
            var langPizza = translator.GetTranslation(_pizzaRepository.GetById(id));
            return new PizzaDTO
            {
                Name = langPizza?.Contents.FirstOrDefault()?.Name,
                Description = langPizza?.Contents.FirstOrDefault()?.Description,
                ImageUrl =  langPizza?.ImageUrl,
                Price =  langPizza?.Price ?? 0
            };
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