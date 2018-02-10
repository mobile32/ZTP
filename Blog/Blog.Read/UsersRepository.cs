using System.Data.SqlClient;
using System.Linq;
using Blog.Query.Models.User;
using Dapper;

namespace Blog.Query
{
    class UsersRepository : IUsersRepository
    {
        private readonly SqlConnection conn;

        public UsersRepository(SqlConnection conn)
        {
            this.conn = conn;
        }
        public UserInfo GetUser(int id)
        {
            return conn.Query<UserInfo>("SELECT id, username FROM Users u WHERE u.id = @id", new { id }).FirstOrDefault();
        }

        public UserInfo GetUser(string username)
        {
            return conn.Query<UserInfo>("SELECT id, username FROM Users u WHERE LOWER(u.username) = @username", new { username = username.ToLower() }).FirstOrDefault();
        }
    }
}
