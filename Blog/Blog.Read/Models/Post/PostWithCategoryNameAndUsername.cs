using System;

namespace Blog.Query.Models.Post
{
    public class PostWithCategoryAndUsername
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public DateTime PostDate { get; set; }
    }
}
