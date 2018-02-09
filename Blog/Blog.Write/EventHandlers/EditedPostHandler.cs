using Blog.Bus;
using Blog.Write.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.EventHandlers
{
    class EditedPostHandler : IEventHandler<EditedPost>
    {
        public void HandleEvent(EditedPost evt)
        {
        }
    }
}
