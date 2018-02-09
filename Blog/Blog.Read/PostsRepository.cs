using Blog.Read.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Blog.Read
{
    class PostsRepository : IPostsRepository
    {
        private readonly SqlConnection _conn;

        public PostsRepository(SqlConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<PostWithCategoryNameAndUsername> GetPostsForList(int page = 1, int pageSize = 20)
        {
            var start = (page - 1) * pageSize;
            CommandDefinition cmd = new CommandDefinition(@"
                                                SELECT *
                                                FROM ( SELECT ROW_NUMBER() OVER ( ORDER BY PostDate DESC) AS RowNum, p.*,c.CategoryName, u.UserName
                                                 FROM Posts p 
                                                    inner join Categories c on p.CategoryId = c.Id
                                                    inner join Users u on p.UserId = u.Id
                                                 ) AS result
                                                WHERE RowNum > @startItem
                                                 AND RowNum <= @endItem
                                                ORDER BY RowNum DESC",
                                                new
                                                {
                                                    startItem = start,
                                                    endItem = start + pageSize
                                                });

            return _conn.Query<PostWithCategoryNameAndUsername>(cmd);
        }
    }
}
