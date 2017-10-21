using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using PizzaStore.BLL.Implementations;
using PizzaStore.BLL.Interfaces;

namespace PizzaStore.BLL
{
    public class PizzaBLLModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LanguageSelector>().As<ILanguageSelector>();
            builder.RegisterType<LanguageSelectorBuilder>().As<ILanguageSelectorBuilder>();
            builder.RegisterType<PizzaService>().As<IPizzaService>();
        }
    }
}
