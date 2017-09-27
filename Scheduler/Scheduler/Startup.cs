using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.MemoryStorage;

[assembly: OwinStartup(typeof(Scheduler.Startup))]

namespace Scheduler
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSerilogLogProvider();
            GlobalConfiguration.Configuration.UseMemoryStorage();
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
