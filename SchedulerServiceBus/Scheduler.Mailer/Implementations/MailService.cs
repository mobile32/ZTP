using FluentMailer.Interfaces;
using Scheduler.Mailer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Mailer.Implementations
{
    public class MailService : IMailService
    {
        private readonly IFluentMailer _fluentMailer;

        public MailService(IFluentMailer fluentMailer)
        {
            _fluentMailer = fluentMailer;
        }

        public async Task SendEmail(string address, string subject, string body)
        {
            await _fluentMailer.CreateMessage()
                .WithViewBody(body)
                .WithReceiver(address)
                .WithSubject(subject)
                .SendAsync();
        }
    }
}
