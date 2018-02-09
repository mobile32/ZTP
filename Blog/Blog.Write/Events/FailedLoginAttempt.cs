using Blog.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.Events
{
    public class FailedLoginAttempt: IEvent
    {
        public string Username { get; private set; }
        public string AttemptedPassword { get; private set; }

        public FailedLoginAttempt(string username, string password)
        {
            Username = username;
            AttemptedPassword = password;
        }
    }
}
