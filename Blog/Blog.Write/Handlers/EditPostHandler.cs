using Blog.Bus;
using Blog.Write.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.Handlers
{
    class EditPostHandler : IHandler<EditPost>
    {
        public void ExecuteCommand(EditPost command)
        {
        }
    }
}
