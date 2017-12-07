using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate.Messages
{
    public class InitFileWatcher
    {
        public string FilePath { get; }
        public InitFileWatcher(string path)
        {
            FilePath = path;
        }
    }
}
