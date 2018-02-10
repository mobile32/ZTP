using Blog.Read.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Read
{
    public interface IUsersRepository
    {
        UserInfo GetUser(int id);
        UserInfo GetUser(string username);
    }
}
