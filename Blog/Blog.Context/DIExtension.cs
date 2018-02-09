using Blog.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Context
{
    public static class DIExtension
    {
        public static void RegisterWriteSide(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
