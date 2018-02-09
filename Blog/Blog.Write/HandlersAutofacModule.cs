using Autofac;
using Blog.Bus;
using Blog.Write.Commands;
using Blog.Write.DAL;
using Blog.Write.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Write
{
    public class WriteSideAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogContext>().AsSelf();

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
