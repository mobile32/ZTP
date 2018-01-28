using Akka.Actor;
using SchedulerUltimate.Shared.Exceptions;
using SchedulerUltimate.Shared.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate.Actors
{
    public class EmailSenderActor : ReceiveActor
    {
        private readonly ILogger logger;
        Guid id = Guid.NewGuid();

        Random r = new Random();
        public EmailSenderActor(ILogger logger)
        {
            Receive<EmailMessage>(x => !string.IsNullOrWhiteSpace(x.Receiver) &&
                                       !string.IsNullOrWhiteSpace(x.Subject) &&
                                       !string.IsNullOrWhiteSpace(x.Text),
                                       sendEmail);
            this.logger = logger;
        }

        private void sendEmail(EmailMessage obj)
        {
            //udawanie wysylania maili
            if (r.NextDouble() < 0.1)
            {
                throw new EmailSendException();
            }
            logger.Information("Message sent by mailer #" + id);
        }

        protected override void PreRestart(Exception reason, object message)
        {
            if (message != null)
            {
                Self.Tell(message);
            }
        }
    }
}
