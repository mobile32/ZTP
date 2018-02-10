﻿using System;

namespace Blog.Query.Models.Post
{
    public class PostWithCategoryNameAndUsername
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public DateTime PostDate { get; set; }
    }
}
