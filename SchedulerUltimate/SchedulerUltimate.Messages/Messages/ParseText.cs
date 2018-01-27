using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerUltimate.Shared.Messages
{
    public class ParseText
    {
        public string Text { get; }

        public ParseText(string text)
        {
            Text = text;
        }
    }
}
