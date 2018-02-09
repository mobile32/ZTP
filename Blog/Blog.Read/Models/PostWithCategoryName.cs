using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Read.Models
{
    public class PostWithCategoryName
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CategoryName { get; set; }
        public DateTime PostDate { get; set; }
    }
}
