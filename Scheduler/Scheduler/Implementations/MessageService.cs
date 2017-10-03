using Scheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Models;
using Scheduler.Parser.Interfaces;

namespace Scheduler.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IParser _parser;

        public MessageService(IParser parser)
        {
            _parser = parser;
        }
        public IEnumerable<EmailMessage> GetMessages(int count = 100)
        {
            return null;
        }

        public void SetSourceFilePath(string inputFile)
        {
        }
    }
}
