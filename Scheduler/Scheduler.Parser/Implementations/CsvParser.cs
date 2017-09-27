using Scheduler.Parser.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Parser.Implementations
{
    class CsvParser : IParser
    {
        public IEnumerable<T> ParseItems<T>(IEnumerable<string> text) where T : class
        {
            using (var stream = new StringReader(string.Join(Environment.NewLine, text)))
            {
                CsvHelper.CsvFactory f = new CsvHelper.CsvFactory();
                var items = f.CreateReader(stream).GetRecords<T>().ToList();
                return items;
            }
        }
    }
}
