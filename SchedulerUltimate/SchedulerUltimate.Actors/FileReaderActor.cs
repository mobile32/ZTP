using Akka.Actor;
using SchedulerUltimate.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate.Actors
{
    public class FileReaderActor : ReceiveActor
    {
        private string _filePath = "";
        private readonly ILogger _logger;
        private FileStream _fileStream;
        private StreamReader _fileStreamReader;

        public FileReaderActor(ILogger logger)
        {
            NotInitialized();
            this._logger = logger;
        }

        public void NotInitialized()
        {
            Receive<InitializeReader>((x) =>
            {
                initialRead(x);
                Become(Initialized);
            });
        }

        public void Initialized()
        {
            Receive<ReadFileToEnd>(x => _filePath == x.FileName, readFileToEnd);
        }

        protected override void PostStop()
        {
            _fileStreamReader.Close();
            _fileStreamReader.Dispose();
            base.PostStop();
        }

        private void initialRead(InitializeReader obj)
        {
            _filePath = obj.FileName;
            _fileStream = new FileStream(Path.GetFullPath(_filePath), FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite);
            _fileStreamReader = new StreamReader(_fileStream, Encoding.UTF8);

            Self.Tell(new ReadFileToEnd(_filePath));
        }

        private void readFileToEnd(ReadFileToEnd obj)
        {
            var text = _fileStreamReader.ReadToEnd();
            _logger.Information(text);
        }

    }
}
