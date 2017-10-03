using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Interfaces
{
    public interface ISchedulerService
    {
        void Init(string inputFile);
        void ProcessMailQueue();
    }
}
