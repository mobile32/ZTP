using Autofac;
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

            builder.RegisterType<SchedulerService>();

            builder.RegisterModule<Mailer.MailerAutofacModule>();
            builder.RegisterModule<Parser.ParserAutofacModule>();

            return builder.Build();
        }
    }
}
