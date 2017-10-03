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
        public IEnumerable<T> ParseItems<T>(string header, IEnumerable<string> text) where T : class
        {
            var joined = string.Join(Environment.NewLine, new[] { header }.Union(text));
            using (var stream = new StringReader(joined))
            {
                var reader = new CsvHelper.CsvFactory().CreateReader(stream);
                reader.Configuration.Delimiter = ";";
                return reader.GetRecords<T>().ToList();
            }
        }
    }
}
