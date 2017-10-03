using Autofac;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Autofac;

namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new SchedulerOptions
            {
                Url = ConfigurationManager.AppSettings["Url"],
                InputFile = ConfigurationManager.AppSettings["InputFile"],
                LoggingFolder = ConfigurationManager.AppSettings["LoggingFolder"],
            };

            var container = AutofacContainer.Configure();
            GlobalConfiguration.Configuration.UseAutofacActivator(container);

            HostFactory.Run(c =>
            {
                c.UseAutofacContainer(container);
                c.Service<Scheduler>(callback: s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted((service, control) => service.Start(options));
                    s.WhenStopped((service, control) => service.Stop());
                });
                c.SetDisplayName("MailSchedulerService");
                c.SetDescription("dupa123");
                c.StartAutomatically();
                c.RunAsLocalService();
            });
        }
    }
}
