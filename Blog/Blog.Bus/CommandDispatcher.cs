using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Blog.Bus
{
    public class CommandDispatcher : ICommandDispatcher
    {
        IComponentContext _ctx;
        public CommandDispatcher(IComponentContext ctx)
        {
            _ctx = ctx;
        }

        public void DispatchCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handlerType = typeof(IHandler<>).MakeGenericType(command.GetType());
            object handler = null;
            try
            {
                handler = _ctx.Resolve(handlerType);
            }
            catch
            {
                // nie ma handlera
                return;
            }
            var executeCommandMethod = handler.GetType().GetMethod(nameof(IHandler<ICommand>.ExecuteCommand));
            executeCommandMethod.Invoke(handler, new object[] { command });
        }
    }
}
