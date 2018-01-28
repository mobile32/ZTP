using Akka.Actor;
using SchedulerUltimate.Shared.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate.Actors
{
    public class FileWatcherActor : ReceiveActor
    {
        private IActorRef fileReaderActor;
        private readonly ILogger _logger;
        private IActorRef _mailingActor;
        private FileSystemWatcher _fsWatcher;

        public FileWatcherActor(ILogger logger)
        {
            _logger = logger;
            Receive<InitFileWatcher>(x => !string.IsNullOrWhiteSpace(x.FilePath) && File.Exists(x.FilePath),
                (x) =>
                {
                    _mailingActor = Context.Sender;
                    initFileWatcher(x);
                });
        }

        private void initFileWatcher(InitFileWatcher obj)
        {
            _fsWatcher = new FileSystemWatcher(Path.GetDirectoryName(obj.FilePath));
            _fsWatcher.Filter = Path.GetFileName(obj.FilePath);
            _fsWatcher.Changed += FsWatcher_Changed;
            _fsWatcher.EnableRaisingEvents = true;

            fileReaderActor = Context.ActorOf(Props.Create<FileReaderActor>(_logger, _mailingActor), "fileReaderActor");
            fileReaderActor.Tell(new InitializeReader(obj.FilePath));
        }

        protected override void PostStop()
        {
            _fsWatcher.Dispose();
            _fsWatcher = null;
            base.PostStop();
        }

        private void FsWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                fileReaderActor.Tell(new ReadFileToEnd(e.FullPath));
            }
        }
    }
}
