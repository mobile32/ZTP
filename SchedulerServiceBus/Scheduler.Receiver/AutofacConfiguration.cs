using Autofac;
using RawRabbit.DependencyInjection.Autofac;
using Scheduler.Implementations;
using Scheduler.Interfaces;
using Scheduler.Receiver;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class AutofacContainer
    {
        public static IContainer Configure(string logFolder)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MailingService>();
            builder.RegisterType<MessageService>().As<IMessageService>().SingleInstance();
            builder.RegisterModule<Mailer.MailerAutofacModule>();
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Logger(lc => lc
                .WriteTo.RollingFile(Path.Combine(logFolder, "receiver-{Date}.txt")))
            .CreateLogger();

            var logger = new Implementations.Logger(Log.Logger);

            builder.RegisterInstance(logger).As<Interfaces.ILogger>().SingleInstance();

            return builder.Build();
        }
    }
}
