using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using PizzaStore.BLL.Interfaces;
using PizzaStore.DAL;

namespace PizzaStore.BLL.Implementations
{
    public class LanguageSelectorBuilder: ILanguageSelectorBuilder
    {
        readonly List<string> _langs = new List<string>();
        public ILanguageSelectorBuilder AddLanguage(string language)
        {
            _langs.Add(language);
            return this;
        }

        public ILanguageSelector Build()
        {
            _langs.Add("");
            LanguageSelector curr = null;
            for (int i = _langs.Count - 1; i >= 0; i--)
            {
                var t = new LanguageSelector(_langs.ElementAt(i)) {Next = curr};
                curr = t;
            }
            return curr;
        }
    }
}
