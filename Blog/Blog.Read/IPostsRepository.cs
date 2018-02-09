using Blog.Read.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Read
{
    public interface IPostsRepository
    {
        IEnumerable<PostWithCategoryName> GetPostsForList(int page = 1, int pageSize = 20);
    }
}
