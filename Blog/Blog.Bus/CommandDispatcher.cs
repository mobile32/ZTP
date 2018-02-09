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

        public void DispatchCommand<TCommand>(TCommand command) where TCommand: ICommand
        {
            try
            {
                var handlerType = typeof(IHandler<>).MakeGenericType(command.GetType());
                var handler = _ctx.Resolve(handlerType);
                var executeCommandMethod = handler.GetType().GetMethod(nameof(IHandler<ICommand>.ExecuteCommand));
                executeCommandMethod.Invoke(handler, new object[] { command });
            }
            catch (Exception e)
            {
                // log
                Console.WriteLine(e.Message);
            }
        }
    }
}
