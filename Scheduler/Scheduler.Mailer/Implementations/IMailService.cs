using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Mailer.Implementations
{
    public interface IMailService
    {
        void SendEmail(string address, string subject, string body);
    }
}
