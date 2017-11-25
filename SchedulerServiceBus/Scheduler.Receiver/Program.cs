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

namespace Scheduler.Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new SchedulerOptions
            {
                LoggingFolder = ConfigurationManager.AppSettings["LoggingFolder"],
            };

            var container = AutofacContainer.Configure(options.LoggingFolder);
            var _logger = container.Resolve<Interfaces.ILogger>();
            GlobalConfiguration.Configuration.UseAutofacActivator(container);
            HostFactory.Run(c =>
            {
                c.UseAutofacContainer(container);
                c.Service<MailingService>(callback: s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted((service, control) => {
                        _logger.Information("Service started...");
                        return service.Start();
                    });
                    s.WhenStopped((service, control) => service.Stop());
                });
                c.SetDisplayName("MailReceiverService");
                c.SetDescription("dupa123");
                c.StartAutomatically();
                c.RunAsLocalService();
            });
        }
    }
}
