using Blog.Write.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Write.DAL
{
    class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options):base(options) {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BlogZTP;Integrated Security=true;");
        }
    }
}
