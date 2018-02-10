using System;
using System.Collections.Generic;
using System.Text;
using Blog.Bus;

namespace Blog.Command.Commands.Post
{
    public class DeleteComment: ICommand
    {
        public int Id { get; }

        public DeleteComment(int id)
        {
            Id = id;
        }
    }
}
