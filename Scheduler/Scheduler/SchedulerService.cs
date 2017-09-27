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

namespace Scheduler
{
    class SchedulerService
    {
        public SchedulerService(IParser p)
        {

        }

        private IDisposable webApp;
        public bool Start(SchedulerOptions options)
        {
            try
            {
                webApp = WebApp.Start<Startup>(options.Url);
                RecurringJob.AddOrUpdate(
                    () => System.IO.File.CreateText(System.IO.Path.Combine(options.LoggingFolder,$"{DateTime.Now.Ticks}.txt")).Close(),
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
