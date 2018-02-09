using Blog.Read.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public PostWithComments GetPostWithComments(int id)
        {
            CommandDefinition cmd = new CommandDefinition(@"
                                               SELECT p.[Id]
                                                      ,[CategoryName]
                                                      ,[Content]
                                                      ,[PostDate]
                                                      ,[Title]
                                                      ,[UserName]
                                               FROM [dbo].[Posts] p
	                                                inner join Categories c on p.CategoryId = c.Id
	                                                inner join Users u on p.UserId = u.Id
                                               WHERE
	                                                p.Id = @id",
                                                new
                                                {
                                                    id
                                                });
            var post = _conn.Query<PostWithComments>(cmd).FirstOrDefault();
            if (post != null)
            {
                post.Comments = _conn.Query<PostComment>("SELECT * FROM Comments c WHERE c.PostId = @id", new { id }).ToList();
            }
            return post;
        }

        public IEnumerable<PostWithCategoryNameAndUsername> GetPostsForList(int page = 1, int pageSize = 20, int? categoryId = null)
        {
            var start = (page - 1) * pageSize;

            var sql = new StringBuilder(@"
                        SELECT *
                        FROM ( SELECT ROW_NUMBER() OVER ( ORDER BY PostDate DESC) AS RowNum,
                        p.Id, p.PostDate, p.Title,LEFT(p.Content, 150) + '...' as Excerpt,c.CategoryName, u.UserName
                         FROM Posts p 
                            inner join Categories c on p.CategoryId = c.Id
                            inner join [Users] u on p.UserId = u.Id");
            if (categoryId.HasValue)
            {
                sql.AppendLine(" WHERE p.CategoryId = @categoryId");
            }
            sql.AppendLine(@") AS result
                             WHERE RowNum > @startItem
                             AND RowNum <= @endItem
                             ORDER BY RowNum DESC");

            CommandDefinition cmd = new CommandDefinition(sql.ToString(),
                                                new
                                                {
                                                    startItem = start,
                                                    endItem = start + pageSize,
                                                    categoryId = categoryId
                                                });

            return _conn.Query<PostWithCategoryNameAndUsername>(cmd);
        }
    }
}
