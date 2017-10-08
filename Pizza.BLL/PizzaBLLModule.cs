using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Pizza.BLL.Implementations;
using Pizza.BLL.Interfaces;

namespace Pizza.BLL
{
    public class PizzaBLLModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PizzaService>().As<IPizzaService>();
        }
    }
}
