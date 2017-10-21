using System.Collections.Generic;
using System.Linq;
using PizzaStore.BLL.Interfaces;
using PizzaStore.DAL;

namespace PizzaStore.BLL.Implementations
{
    public class LanguageSelector: ILanguageSelector
    {
        private readonly string _lang;

        public LanguageSelector Next { get; set; }

        public LanguageSelector(string lang)
        {
            _lang = lang;
        }

        public Pizza GetTranslation(Pizza pizza)
        {
            if (pizza == null) return null;
            var result = new Pizza
            {
                Id = pizza.Id,
                ImageUrl = pizza.ImageUrl,
                Price = pizza.Price
            };

            var translation = pizza.Contents.FirstOrDefault(x => x.LanguageCode.ToLower().StartsWith(_lang.ToLower()));

            if (translation == null) return Next?.GetTranslation(pizza);
            result.Contents = new List<PizzaContent> { translation };
            return result;
        }
    }
}