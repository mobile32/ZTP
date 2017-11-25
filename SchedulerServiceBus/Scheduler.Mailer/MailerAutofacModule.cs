using Autofac;
using Autofac.Core;
using FluentMailer.Factory;
using FluentMailer.Interfaces;
using Scheduler.Mailer.Implementations;
using Scheduler.Mailer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Mailer
{
    public class MailerAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MailService>().As<IMailService>();
            builder.Register(c => FluentMailerFactory.Create()).As<IFluentMailer>();
        }
    }
}
