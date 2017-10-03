using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Interfaces
{
    public interface IMessageService
    {
        void SetSourceFilePath(string inputFile);
        IEnumerable<EmailMessage> GetMessages(int count = 100);
    }
}
