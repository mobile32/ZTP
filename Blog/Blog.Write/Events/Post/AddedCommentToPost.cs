using System;
using System.Collections.Generic;
using System.Text;
using Blog.Bus;

namespace Blog.Command.Events.Post
{
    class AddedCommentToPost: IEvent
    {
        public int PostId { get; }
        public string Author { get; }
        public string Comment { get; }

        public AddedCommentToPost(int postId, string author, string comment)
        {
            PostId = postId;
            Author = author;
            Comment = comment;
        }
    }
}
