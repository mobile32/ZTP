using Hangfire;
using RawRabbit.Extensions.BulkGet;
using RawRabbit.Extensions.Client;
using RawRabbit.vNext;
using Scheduler.Interfaces;
using Scheduler.Mailer.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin.Hosting;

namespace Scheduler.Receiver
{
    class MailingService
    {
        public MailingService(ILogger logger, IMailService mailer)
        {
            _logger = logger;
            _mailer = mailer;
            client = RawRabbitFactory.Create();
        }
        private readonly ILogger _logger;
        private readonly IMailService _mailer;
        private readonly IBusClient client;
        private IDisposable webApp;

        public void sendMessages(int count)
        {
            var bulk = client
                            .GetMessages(cfg => cfg
                            .ForMessage<SendMailMessageCommand>(msg => msg
                                .FromQueues("sendmailmessagecommand_scheduler_receiver")
                                .WithBatchSize(count))
                            );

            var msgs = bulk.GetMessages<SendMailMessageCommand>();
            _logger.Debug("Got messages: " + msgs.Count());
            msgs.ToList().ForEach(async msg =>
            {
                try
                {
                    var x = msg.Message;
                    await _mailer.SendEmail(x.Address, x.Subject, x.Body);
                    msg.Ack();
                }
                catch (Exception)
                {
                    msg.Nack();
                }
            });
        }

        public bool Start()
        {
            try
            {
                var port = new Random().Next(2000, 2100);
                webApp = WebApp.Start<Startup>("http://localhost:"+ port);
                _logger.Information("Stared at: http://localhost:"+ port);

                RecurringJob.AddOrUpdate(
                    () => sendMessages(100),
                    Cron.Minutely()
                );
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
                webApp.Dispose();
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
