using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Query.Models.Category
{
    public class CategoryWithPostCount
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int PostCount { get; set; }
    }
}
