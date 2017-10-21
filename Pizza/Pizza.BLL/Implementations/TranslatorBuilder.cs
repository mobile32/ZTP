using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using PizzaStore.DAL;

namespace PizzaStore.BLL.Implementations
{
    public class TranslatorBuilder
    {
        readonly List<string> _langs = new List<string>();
        public TranslatorBuilder AddLanguage(string language)
        {
            _langs.Add(language);
            return this;
        }

        public Translator Build()
        {
            _langs.Add("");
            Translator curr = null;
            for (int i = _langs.Count - 1; i >= 0; i--)
            {
                var t = new Translator(_langs.ElementAt(i)) {Next = curr};
                curr = t;
            }
            return curr;
        }
    }

    public class Translator
    {
        private readonly string _lang;

        public Translator Next { get; set; }
        public Lazy<Translator> NextLazy { get; set; }

        public Translator(string lang)
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
