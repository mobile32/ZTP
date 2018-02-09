using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Read
{
    public class ReadSideAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();
        }
    }
}
