
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Bus
{
    public class BusAutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventStoreWriter>().As<IEventStoreWriter>().SingleInstance();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<CommandBus>().As<ICommandBus>();
            builder.RegisterType<EventBus>().As<IEventBus>();
            builder.RegisterType<EventPublisher>().As<IEventPublisher>();
        }
    }
}
