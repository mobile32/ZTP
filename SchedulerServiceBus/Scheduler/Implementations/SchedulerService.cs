using Scheduler.Interfaces;
using Scheduler.Mailer.Implementations;
using Scheduler.Mailer.Interfaces;
using Scheduler.Parser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Implementations
{
    public class SchedulerService : ISchedulerService
    {
        private readonly IMessageService _messageList;
        private readonly ILogger _logger;
        private readonly IMailService _mailer;

        public SchedulerService(IMailService mailer, IMessageService address, ILogger logger)
        {
            _mailer = mailer;
            _messageList = address;
            _logger = logger;
        }

        public void Init(string inputFile)
        {
            _messageList.SetSourceFilePath(inputFile);
        }

        public void ProcessMailQueue()
        {
            try
            {
                var msgs = _messageList.GetMessages().ToList();
                if (msgs.Count > 0)
                {
                    msgs.ForEach(x=> _mailer.SendEmail(x.Address, x.Subject, x.Body));
                    _logger.Information($"Messages sent successfully");
                }
            }
            catch (Exception e)
            {
                _logger.Error($"Error while sending messages [{e.Message}]");
            }
        }
    }
}
