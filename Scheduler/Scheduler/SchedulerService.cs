using Scheduler.Parser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Scheduler
{
    class SchedulerService
    {
        public SchedulerService(IParser parser)
        {

        }
        public bool Start()
        {
            return true;
        }

        public bool Stop()
        {
            return true;
        }
    }
}
