using Blog.Bus;
using Blog.Write.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.EventHandlers
{
    class UserEventsHandler : IEventHandler<FailedLoginAttempt>,
                              IEventHandler<InvalidUserLoginAttempt>,
                              IEventHandler<UserLoggedIn>
                              //IEventHandler<UserRegistered>,
    {
        public void HandleEvent(FailedLoginAttempt evt)
        {
            //loguj
        }

        public void HandleEvent(InvalidUserLoginAttempt evt)
        {
        }

        public void HandleEvent(UserLoggedIn evt)
        {
        }

        //public void HandleEvent(UserRegistered evt)
        //{
        //}
    }
}
