using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Blog.Query.Models.Post;
using Dapper;

namespace Blog.Query
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
                                                      ,c.Id as CategoryId
                                                      ,[CategoryName]
                                                      ,[Content]
                                                      ,[Description]
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

        public IEnumerable<PostWithCategoryAndUsername> GetPostsForViewing(int page = 1, int pageSize = 20, int? categoryId = null)
        {
            var start = (page - 1) * pageSize;

            var sql = new StringBuilder(@"
                        SELECT *
                        FROM ( SELECT ROW_NUMBER() OVER ( ORDER BY PostDate DESC) AS RowNum,
                        p.Id, p.PostDate, p.Title,p.Description,c.Id as CategoryId, c.CategoryName, u.UserName
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
                             ORDER BY PostDate DESC");

            CommandDefinition cmd = new CommandDefinition(sql.ToString(),
                                                new
                                                {
                                                    startItem = start,
                                                    endItem = start + pageSize,
                                                    categoryId = categoryId
                                                });

            return _conn.Query<PostWithCategoryAndUsername>(cmd);
        }

        public IEnumerable<PostWithCategoryAndUsername> GetPostsForDashboard()
        {
            return GetPostsForViewing(1, 1000000000);
        }

        public Post GetPostById(int id)
        {
            CommandDefinition cmd = new CommandDefinition(@"
                                               SELECT p.[Id]
                                                      ,[Title]
                                                      ,[Description]
                                                      ,[Content]
                                                      ,[PostDate]
                                                      ,[CategoryId]
                                               FROM [dbo].[Posts] p
                                               WHERE
	                                                p.Id = @id",
                new
                {
                    id
                });
            return _conn.Query<Post>(cmd).FirstOrDefault();
        }
    }
}
