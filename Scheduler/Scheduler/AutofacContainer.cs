using Autofac;
using Scheduler.Implementations;
using Scheduler.Interfaces;
using Serilog;
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

            builder.RegisterType<Scheduler>();
            builder.RegisterType<SchedulerService>();
            builder.RegisterType<SchedulerService>().As<ISchedulerService>();
            builder.RegisterType<MessageService>().As<IMessageService>().SingleInstance();
            builder.RegisterModule<Mailer.MailerAutofacModule>();
            builder.RegisterModule<Parser.ParserAutofacModule>();

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Logger(lc => lc
                .WriteTo.RollingFile(Path.Combine(logFolder, "{Date}.txt")))
            .CreateLogger();

            var logger = new Logger(Log.Logger);

            builder.RegisterInstance(logger).As<Interfaces.ILogger>().SingleInstance();

            return builder.Build();
        }
    }
}
