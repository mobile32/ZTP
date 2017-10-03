using Autofac;
using Scheduler.Implementations;
using Scheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class AutofacContainer
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Scheduler>();
            builder.RegisterType<SchedulerService>();
            builder.RegisterType<SchedulerService>().As<ISchedulerService>();
            builder.RegisterType<MessageService>().As<IMessageService>().SingleInstance();
            builder.RegisterModule<Mailer.MailerAutofacModule>();
            builder.RegisterModule<Parser.ParserAutofacModule>();

            return builder.Build();
        }
    }
}
