using System.Collections.Generic;
using Blog.Query.Models.Post;

namespace Blog.Query
{
    public interface IPostsRepository
    {
        PostWithComments GetPostWithComments(int id);
        IEnumerable<PostWithCategoryAndUsername> GetPostsForList(int page = 1, int pageSize = 20, int? categoryId = null);
    }
}
