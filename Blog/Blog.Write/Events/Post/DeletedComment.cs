using System;
using System.Collections.Generic;
using System.Text;
using Blog.Bus;

namespace Blog.Command.Events.Post
{
    public class DeletedComment: IEvent
    {
        public int Id { get; }

        public DeletedComment(int id)
        {
            Id = id;
        }
    }
}
