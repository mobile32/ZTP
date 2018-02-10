using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.DAL
{
    public static class DIExtension
    {
        public static void RegisterBlogContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
