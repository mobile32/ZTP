using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using PizzaStore.DAL.Implementations;
using PizzaStore.DAL.Interfaces;

namespace PizzaStore.DAL
{
    public class PizzaDALModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new PizzaDbConnection()).As<PizzaDbConnection>();
            builder.RegisterType<PizzaRepository>().As<IPizzaRepository>();
        }
    }
}
