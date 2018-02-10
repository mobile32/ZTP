using System;
using Blog.Bus;

namespace Blog.Command.Events.User
{
    class UserLoggedIn: IEvent
    {
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public DateTime LoginDate { get; private set; }

        public UserLoggedIn(int userId, string username, DateTime loginDate)
        {
            UserId = UserId;
            Username = username;
            LoginDate = loginDate;
        }
    }
}
