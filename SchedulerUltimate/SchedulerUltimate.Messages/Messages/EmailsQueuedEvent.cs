using SchedulerUltimate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate.Shared.Messages
{
    public class EmailsQueuedEvent
    {
        public ImmutableList<EmailMessage> Items { get; }

        public EmailsQueuedEvent(IEnumerable<EmailMessage> emails)
        {
            Items = emails.ToImmutableList();
        }
    }
}
