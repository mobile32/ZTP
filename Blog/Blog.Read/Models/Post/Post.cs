using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Query.Models.Post
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public DateTime PostDate { get; set; }
    }
}
