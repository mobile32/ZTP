using Akka.Actor;
using SchedulerUltimate.Shared.Messages;
using SchedulerUltimate.Shared.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate.Actors
{
    public class ParserActor : ReceiveActor
    {
        private readonly ILogger logger;

        public ParserActor(ILogger logger)
        {
            this.logger = logger;

            Receive<ParseText>(x => !string.IsNullOrWhiteSpace(x.Text), parseText);
        }

        private void parseText(ParseText text)
        {
            var lines = text.Text.Replace("\r", "")
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()).ToList();
            var emails = lines.Select(x =>
            {
                try
                {
                    var parts = x.Split(';');
                    return new EmailMessage(parts[0], parts[1], parts[2]);
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                    return null;
                }
            })
            .Where(x => x != null).ToList();
            if (emails.Any())
            {
                logger.Debug("Parsed items: " + emails.Count);
                Context.Sender.Tell(new EmailsQueuedEvent(emails));
            }
            else
            {
                logger.Debug("No items parsed");
            }
        }
    }
}
