using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class SendMailMessageCommand
    {
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Body{ get; set; }
    }
}
