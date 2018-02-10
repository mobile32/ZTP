using System;

namespace Blog.Bus
{
    public class EventBus: IEventBus
    {
        private readonly IEventPublisher _publisher;
        private readonly IEventStoreWriter _storeWriter;

        public EventBus(IEventPublisher dispatcher, IEventStoreWriter storeWriter)
        {
            _publisher = dispatcher;
            _storeWriter = storeWriter;
        }

        public void PublishEvent<TEvent>(TEvent evt) where TEvent: IEvent
        {
            _storeWriter.StoreEvent(evt);

            _publisher.PublishEvent(evt);
        }
    }
}
