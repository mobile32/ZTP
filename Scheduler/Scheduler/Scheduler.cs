using Scheduler.Parser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;
using Owin;
using Microsoft.Owin.Hosting;
using Hangfire;
using Scheduler.Interfaces;
using Scheduler.Implementations;
using System.IO;

namespace Scheduler
{
    class Scheduler
    {
        public Scheduler(ISchedulerService service)
        {
            _service = service;
        }
        private IDisposable webApp;
        private readonly ISchedulerService _service;

        public bool Start(SchedulerOptions options)
        {
            try
            {
                _service.Init(options.InputFile);
                webApp = WebApp.Start<Startup>(options.Url);
                RecurringJob.AddOrUpdate(
                    () => _service.ProcessMailQueue(),
                    Cron.Minutely()
                );
                return true;
            }
            catch (Exception ex)
            {
                //_logger.Error($"Topshelf starting occured errors:{ex.ToString()}");
                return false;
            }
        }
        public bool Stop()
        {
            try
            {
                webApp?.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                //_logger.Error($"Topshelf stopping occured errors:{ex.ToString()}");
                return false;
            }

        }
    }
}
