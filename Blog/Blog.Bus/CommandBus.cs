using System;

namespace Blog.Bus
{
    public class CommandBus: ICommandBus
    {
        ICommandDispatcher _dispatcher;

        public CommandBus(ICommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void ProcessCommand(ICommand command)
        {
            _dispatcher.DispatchCommand(command);
        }
    }
}
