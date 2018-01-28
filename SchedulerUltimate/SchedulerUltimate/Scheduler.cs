using Akka.Actor;
using SchedulerUltimate.Actors;
using SchedulerUltimate.Shared.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate
{
    class Scheduler
    {
        public Scheduler(ILogger logger)
        {
            _logger = logger;
        }
        private readonly ILogger _logger;
        private ActorSystem _actorSystem;

        public bool Start(string inputFile)
        {
            try
            {
                _actorSystem = ActorSystem.Create("SchedulerUltimate");
                var mailingActor = _actorSystem.ActorOf(Props.Create<MailingActor>(_logger),"mailingActor");
                mailingActor.Tell(new InitFileWatcher(inputFile));
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Topshelf starting occured errors:{ex.ToString()}");
                return false;
            }
        }
        public bool Stop()
        {
            try
            {
                _actorSystem.Terminate().Wait();
                _actorSystem.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Topshelf stopping occured errors:{ex.ToString()}");
                return false;
            }
        }
    }
}
