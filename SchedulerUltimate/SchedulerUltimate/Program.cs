using Autofac;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Autofac;

namespace SchedulerUltimate
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = ConfigurationManager.AppSettings["InputFile"];
            var loggingFolder = ConfigurationManager.AppSettings["LoggingFolder"];

            var container = AutofacContainer.Configure(loggingFolder);
            var _logger = container.Resolve<ILogger>();

            HostFactory.Run(c =>
            {
                c.UseAutofacContainer(container);
                c.Service<Scheduler>(callback: s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted((service, control) =>
                    {
                        _logger.Information("Service started...");
                        return service.Start(inputFile);
                    });
                    s.WhenStopped((service, control) => service.Stop());
                });
                c.SetDisplayName("SchedulerUltimate");
                c.SetDescription("Scheduler using ActorModel");
                c.StartAutomatically();
                c.RunAsLocalService();
            });
        }
    }
}
