using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Bus
{
    class EventPublisher : IEventPublisher
    {
        private readonly Func<Type, IEnumerable<IEventHandler>> _factory;

        public EventPublisher(Func<Type,IEnumerable<IEventHandler>> factory)
        {
            _factory= factory;
        }

        public void PublishEvent<TEvent>(TEvent evt) where TEvent : IEvent
        {
            var handlers = _factory(typeof(TEvent)).Cast<IEventHandler<TEvent>>();
            foreach (var handler in handlers)
            {
                handler.HandleEvent(evt);
            }
        }
    }
}
