using System.Collections.Generic;
using Blog.Query.Models.Post;

namespace Blog.Query
{
    public interface IPostsRepository
    {
        Post GetPostById(int id);
        PostWithComments GetPostWithComments(int id);
        IEnumerable<PostWithCategoryAndUsername> GetPostsForViewing(int page = 1, int pageSize = 20, int? categoryId = null);
        IEnumerable<PostWithCategoryAndUsername> GetPostsForDashboard();
    }
}
