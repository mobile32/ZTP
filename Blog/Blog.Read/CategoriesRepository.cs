using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Blog.Query.Models.Category;
using Dapper;

namespace Blog.Query
{
    class CategoriesRepository : ICategoriesRepository
    {
        private readonly SqlConnection _conn;

        public CategoriesRepository(SqlConnection conn)
        {
            _conn = conn;
        }
        public ICollection<CategoryWithPostCount> GetCategoriesWithPostCounts()
        {
            return _conn.Query<CategoryWithPostCount>(@"
                                    select c.Id, c.CategoryName, ISNULL(p.postCount,0) as PostCount
                                    from Categories c
                                    left join 
                                    (select CategoryId as cid, count(CategoryId) as postCount from Posts group by CategoryId)
                                     as p
                                    on c.Id = p.cid
                                    order by CategoryName
                                                    ").ToList();
        }

        public ICollection<Category> GetCategories()
        {
            return _conn.Query<Category>(@"
                                            select c.Id, c.CategoryName from Categories c order by c.CategoryName
                                          ").ToList();
        }
    }
}
