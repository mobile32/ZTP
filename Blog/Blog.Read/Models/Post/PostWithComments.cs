﻿using System;
using System.Collections.Generic;

namespace Blog.Query.Models.Post
{
    public class PostWithComments
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public DateTime PostDate { get; set; }

        public ICollection<PostComment> Comments { get; set; }
    }

    public class PostComment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
