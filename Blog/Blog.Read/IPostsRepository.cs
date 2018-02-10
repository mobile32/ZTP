using Blog.Read.Models.Post;
using System.Collections.Generic;

namespace Blog.Read
{
    public interface IPostsRepository
    {
        PostWithComments GetPostWithComments(int id);
        IEnumerable<PostWithCategoryNameAndUsername> GetPostsForList(int page = 1, int pageSize = 20, int? categoryId = null);
    }
}
