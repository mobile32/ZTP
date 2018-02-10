using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Blog.Read.Models.User;
using Dapper;

namespace Blog.Read
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
