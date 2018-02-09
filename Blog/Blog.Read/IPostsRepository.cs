using Blog.Read.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Read
{
    public interface IPostsRepository
    {
        PostWithComments GetPostWithComments(int id);
        IEnumerable<PostWithCategoryNameAndUsername> GetPostsForList(int page = 1, int pageSize = 20, int? categoryId = null);
    }
}
