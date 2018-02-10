using Blog.Query.Models.User;

namespace Blog.Query
{
    public interface IUsersRepository
    {
        UserInfo GetUser(int id);
        UserInfo GetUser(string username);
    }
}
