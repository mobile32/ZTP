using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Mailer.Interfaces
{
    public interface IMailService
    {
        Task SendEmail(string address, string subject, string body);
    }
}
