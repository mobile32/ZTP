using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Pizza.DAL.Implementations;
using Pizza.DAL.Interfaces;

namespace Pizza.DAL
{
    public class PizzaDALModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PizzaRepository>().As<IPizzaRepository>();
        }
    }
}
