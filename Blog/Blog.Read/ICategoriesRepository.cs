using System.Collections.Generic;
using Blog.Query.Models.Category;

namespace Blog.Query
{
    public interface ICategoriesRepository
    {
        ICollection<CategoryWithPostCount> GetCategoriesWithPostCounts();
    }
}