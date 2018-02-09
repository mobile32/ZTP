using Blog.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.Events
{
    class InvalidUserLoginAttempt: IEvent
    {
        public string AttemptedUsername { get; private set; }

        public InvalidUserLoginAttempt(string username, string password)
        {
            AttemptedUsername = username;
        }
    }
}
