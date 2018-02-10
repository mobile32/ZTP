using Blog.Bus;

namespace Blog.Command.Events.User
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
