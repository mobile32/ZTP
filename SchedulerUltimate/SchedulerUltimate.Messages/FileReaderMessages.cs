using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate.Messages
{
    public class InitializeReader
    {
        public InitializeReader(string fileName)
        {
            FileName = fileName;
        }
        public string FileName { get; private set; }
    }

    public class ReadFileToEnd
    {
        public ReadFileToEnd(string fileName)
        {
            FileName = fileName;
        }
        public string FileName { get; private set; }
    }

    public class CloseReader
    {
        public CloseReader(string fileName)
        {
            FileName = fileName;
        }
        public string FileName { get; private set; }
    }
}
