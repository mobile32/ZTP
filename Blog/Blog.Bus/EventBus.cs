using System;

namespace Blog.Bus
{
    public class EventBus: IEventBus
    {
        IEventPublisher _publisher;

        public EventBus(IEventPublisher dispatcher)
        {
            _publisher = dispatcher;
        }

        public void PublishEvent<TEvent>(TEvent evt) where TEvent: IEvent
        {
            // zapis do event store itp

            _publisher.PublishEvent(evt);
        }
    }
}
