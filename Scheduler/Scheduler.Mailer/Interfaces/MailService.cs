using Scheduler.Mailer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Mailer.Interfaces
{
    public class MailService : IMailService
    {
        public void SendEmail(string address, string subject, string body)
        {
        }
    }
}
