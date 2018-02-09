using Blog.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.Events.User
{
    class UserRegistered: IEvent
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string Salt { get; private set; }

        public UserRegistered(string username, string passwordHash, string salt)
        {
            Username = username;
            PasswordHash = passwordHash;
            Salt = salt;
        }
    }
}
