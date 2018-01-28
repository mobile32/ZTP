using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate.Shared.Models
{
    public class EmailMessage
    {
        public string Receiver { get; }
        public string Subject { get; }
        public string Text { get;}
        public EmailMessage(string receiver, string subject, string text)
        {
            Receiver = receiver;
            Subject = subject;
            Text = text;
        }
    }
}
