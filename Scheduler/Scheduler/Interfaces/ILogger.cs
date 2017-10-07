using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Interfaces
{
    public interface ILogger
    {
        void Information(string messageTemplate, params object[] parameters);
        void Warning(string messageTemplate, params object[] parameters);
        void Error(string messageTemplate, params object[] parameters);
    }
}
