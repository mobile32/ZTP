using Akka.Actor;
using Akka.Routing;
using SchedulerUltimate.Shared.Exceptions;
using SchedulerUltimate.Shared.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate.Actors
{
    public class MailingActor : ReceiveActor
    {
        private readonly ILogger _logger;
        private IActorRef mailSender;
        public MailingActor(ILogger logger)
        {
            this._logger = logger;
            var fileWatcher = Context.ActorOf(Props.Create<FileWatcherActor>(_logger), "fileWatcherActor");


            var props = Props.Create<EmailSenderActor>(_logger).WithRouter(new RoundRobinPool(5));
            mailSender = Context.ActorOf(props, "sender");

            Receive<InitFileWatcher>(x =>
            {
                fileWatcher.Tell(x);
                Become(Initialized);
            });
        }

        void Initialized()
        {
            Receive<EmailsQueuedEvent>(x =>
            {
                _logger.Information("Received:" + x.Items.Count);
                x.Items.ForEach(mail => mailSender.Tell(mail));
            });
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(
                maxNrOfRetries: 100,
                withinTimeRange: TimeSpan.FromMinutes(1),
                localOnlyDecider: ex =>
                {
                    switch (ex)
                    {
                        case EmailSendException ese:
                            return Directive.Restart;
                        default:
                            _logger.Error(ex.Message);
                            return Directive.Restart;
                    }
                });
        }
    }
}
