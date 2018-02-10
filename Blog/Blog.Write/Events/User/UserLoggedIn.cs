using System;
using Blog.Bus;

namespace Blog.Command.Events.User
{
    class UserLoggedIn: IEvent
    {
        public int UserId { get; }
        public string Username { get; }
        public DateTime LoginDate { get; }

        public UserLoggedIn(int userId, string username, DateTime loginDate)
        {
            UserId = userId;
            Username = username;
            LoginDate = loginDate;
        }
    }
}
