using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Blog.Bus
{
    class EventStoreWriter : IEventStoreWriter
    {
        private readonly IEventStoreConnection _connection;

        public EventStoreWriter()
        {
            _connection =
                EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));

            _connection.ConnectAsync().Wait();
        }
        public void StoreEvent<TEvent>(TEvent evt) where TEvent : IEvent
        {
            var @event = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(evt));

            var eventData = new EventData(Guid.NewGuid(), typeof(TEvent).Name,true,@event,new byte[]{});

            _connection.AppendToStreamAsync("blog-stream", ExpectedVersion.Any,eventData).Wait();

        }
    }
}
