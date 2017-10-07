using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Parser.Interfaces
{
    public interface IParser
    {
        ICollection<T> ParseItems<T>(string header, IEnumerable<string> text) where T:class;
    }
}
