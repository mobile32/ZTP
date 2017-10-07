using Scheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Models;
using Scheduler.Parser.Interfaces;
using System.IO;

namespace Scheduler.Implementations
{
    public class MessageService : IMessageService
    {
        private string _filePath = "";
        private int _position = 0;
        private readonly IParser _parser;
        private readonly ILogger _logger;

        public MessageService(IParser parser, ILogger logger)
        {
            _parser = parser;
            _logger = logger;
        }
        public IEnumerable<EmailMessage> GetMessages(int count = 100)
        {
            IEnumerable<string> data;
            try
            {
                data = File.ReadLines(_filePath).Skip(_position).Take(count);
            }
            catch (Exception e)
            {
                _logger.Error($"Error while retrieving data from file. [{e.Message}]");
                return new EmailMessage[] { };
            }
            var itemsCount = data.Count();
            _position += itemsCount;
            if (itemsCount > 0)
            {
                _logger.Information($"Retrieved {itemsCount} messages");
            }
            else
            {
                _logger.Information("No pending messages to be sent");
            }
            ICollection<EmailMessage> items;
            try
            {
                items = _parser.ParseItems<EmailMessage>("Address;Subject;Body", data);
            }
            catch (Exception e)
            {
                _logger.Error($"Error while parsing data from file. [{e.Message}]");
                items = new List<EmailMessage>();
            }
            return items;

        }

        public void SetSourceFilePath(string inputFile)
        {
            if (File.Exists(inputFile))
            {
                _filePath = inputFile;
                _position = 0;
                _logger.Information($"Source file set to: \"{_filePath}\"");
            }
            else
            {
                _logger.Error($"File \"{inputFile}\" doesn't exist");
            }
        }
    }
}
