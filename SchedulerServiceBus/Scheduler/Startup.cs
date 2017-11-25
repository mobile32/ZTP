using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Scheduler.Startup))]

namespace Scheduler
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
