using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Bus
{
    #region Command
    public interface ICommand { }
    public interface IHandler { }
    public interface IHandler<TCommand> : IHandler where TCommand : ICommand
    {
        void ExecuteCommand(TCommand command);
    }
    public interface ICommandDispatcher
    {
        void DispatchCommand<TCommand>(TCommand command) where TCommand: ICommand;
    }
    public interface ICommandBus
    {
        void ProcessCommand(ICommand command);
    }
    #endregion

    #region Events
    public interface IEvent { }
    public interface IEventHandler { }
    public interface IEventHandler<TEvent> : IEventHandler where TEvent : IEvent
    {
        void HandleEvent(TEvent evt);
    }
    public interface IEventPublisher
    {
        void PublishEvent<TEvent>(TEvent evt) where TEvent: IEvent;
    }
    public interface IEventBus
    {
        void PublishEvent<TEvent>(TEvent evt) where TEvent : IEvent;
    }
    #endregion
}