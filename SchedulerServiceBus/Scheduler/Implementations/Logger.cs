using Scheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Implementations
{
    public class Logger : ILogger
    {
        private readonly Serilog.ILogger logger;

        public Logger(Serilog.ILogger logger)
        {
            this.logger = logger;
        }

        public void Error(string messageTemplate, params object[] parameters)
        {
            logger.Error(messageTemplate, parameters);
        }

        public void Information(string messageTemplate, params object[] parameters)
        {
            logger.Information(messageTemplate, parameters);
        }

        public void Warning(string messageTemplate, params object[] parameters)
        {
            logger.Warning(messageTemplate, parameters);
        }

        public void Debug(string messageTemplate, params object[] parameters)
        {
            logger.Debug(messageTemplate, parameters);
        }
    }
}
