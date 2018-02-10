using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Blog.Bus;

namespace Blog.Command
{
    public class WriteSideAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterTypes
                    (
                        GetType().Assembly.GetTypes()
                                          .Where(x => x.GetInterface(nameof(IHandler)) != null).ToArray()
                    )
                   .AsImplementedInterfaces();

            builder.RegisterTypes
                    (
                        GetType().Assembly.GetTypes()
                                          .Where(x => x.GetInterface(nameof(IEventHandler)) != null).ToArray()
                    )
                   .AsImplementedInterfaces();

            builder.Register<Func<Type, IEnumerable<IEventHandler>>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    var handlerType = typeof(IEventHandler<>).MakeGenericType(t);
                    var handlersCollectionType = typeof(IEnumerable<>).MakeGenericType(handlerType);
                    return (IEnumerable<IEventHandler>)ctx.Resolve(handlersCollectionType);
                };
            });
        }
    }
}
