using System;
using System.Collections.Generic;
using System.Text;
using Blog.Bus;

namespace Blog.Command.Commands.Post
{
    public class DeletePost : ICommand
    {
        public int Id { get; }

        public DeletePost(int id)
        {
            Id = id;
        }
    }
}
