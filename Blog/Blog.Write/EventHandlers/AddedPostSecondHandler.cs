using Blog.Bus;
using Blog.Write.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.EventHandlers
{
    class AddedPostSecondHandler : IEventHandler<AddedPost>
    {
        public void HandleEvent(AddedPost evt)
        {
            //2
        }
    }
}
