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
        private readonly IMailService _mailer;

        public SchedulerService(IMailService mailer, IMessageService address)
        {
            _mailer = mailer;
            _messageList = address;
        }

        public void Init(string inputFile)
        {
            _messageList.SetSourceFilePath(inputFile);
        }

        public void ProcessMailQueue()
        {
            _messageList.GetMessages().ToList().ForEach(x=> _mailer.SendEmail(x.Address, x.Subject, x.Body));
        }
    }
}
