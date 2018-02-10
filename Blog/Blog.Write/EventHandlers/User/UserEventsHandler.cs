using Blog.Bus;
using Blog.Command.Events.User;

namespace Blog.Command.EventHandlers.User
{
    class UserEventsHandler : IEventHandler<FailedLoginAttempt>,
                              IEventHandler<InvalidUserLoginAttempt>,
                              IEventHandler<UserLoggedIn>,
                              IEventHandler<UserRegistered>
    {
        public void HandleEvent(InvalidUserLoginAttempt evt)
        {
        }

        public void HandleEvent(FailedLoginAttempt evt)
        {
            //lockout?
        }


        public void HandleEvent(UserLoggedIn evt)
        {
        }

        public void HandleEvent(UserRegistered evt)
        {
        }
    }
}
