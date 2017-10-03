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

        public MessageService(IParser parser)
        {
            _parser = parser;
        }
        public IEnumerable<EmailMessage> GetMessages(int count = 100)
        {
            try
            {
                var data = File.ReadLines(_filePath).Skip(_position).Take(count);
                _position += data.Count();
                return _parser.ParseItems<EmailMessage>("Address;Subject;Body",data);
            }
            catch (Exception e)
            {
                // błąd podczas odczytu, nie ustawiona ścieżka lub plik usunięty
                return new EmailMessage[] { };
            }
        }

        public void SetSourceFilePath(string inputFile)
        {
            if (File.Exists(inputFile))
            {
                _filePath = inputFile;
                _position = 0;
            }
            else
            {
                
                // nie ma pliku
            }
        }
    }
}
