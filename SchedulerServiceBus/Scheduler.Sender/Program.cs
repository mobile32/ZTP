using Autofac;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.DependencyInjection.Autofac;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new RawRabbitConfiguration();

            var builder = new ContainerBuilder();
            builder.RegisterRawRabbit(cfg);
            var container = builder.Build();
            //"guest:guest@localhost:5672/",
            var client = container.Resolve<IBusClient>();

            var r = new Random();
            Enumerable.Range(0, 400).Select(x => new SendMailMessageCommand
            {
                Address = $"user{x % 20}@company.pl",
                Body = "Lorem ipsum",
                Subject = $"Issue#{r.Next(100)}"
            }).ToList().ForEach(x =>
            {
                client.PublishAsync<SendMailMessageCommand>(x);
            });

        }
    }
}
