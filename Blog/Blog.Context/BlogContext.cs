using Blog.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options):base(options) {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
