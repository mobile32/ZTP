using Blog.Bus;

namespace Blog.Command.Events.User
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
