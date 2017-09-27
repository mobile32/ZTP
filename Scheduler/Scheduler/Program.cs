using Autofac;
using System;
using System.Collections.Generic;
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
            HostFactory.New(c =>
            {
                c.UseAutofacContainer(AutofacContainer.Configure());
                c.Service<SchedulerService>(s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
            });
        }
    }
}
