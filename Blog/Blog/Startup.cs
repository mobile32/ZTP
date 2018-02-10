using System;
using System.Data.SqlClient;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blog.Bus;
using Blog.Command;
using Blog.Context;
using Blog.Query;
using Blog.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("BlogContext");

            services.AddMvc();
            services.RegisterWriteSide(connString);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/login";
                        options.LogoutPath = "/logout";
                    });

            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<AuthService>().AsSelf();
            builder.RegisterModule<BusAutofacModule>();
            builder.RegisterModule<ReadSideAutofacModule>();
            builder.RegisterModule<WriteSideAutofacModule>();

            builder.Register(x =>
            {
                var conn = new SqlConnection(connString);
                conn.Open();
                return conn;
            }).AsSelf().InstancePerLifetimeScope();

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "login",
                    template: "login",
                    defaults: new { controller = "Auth", action = "Login" });

                routes.MapRoute(
                    name: "logout",
                    template: "logout",
                    defaults: new { controller = "Auth", action = "Logout" });

                routes.MapRoute(
                    name: "register",
                    template: "register",
                    defaults: new { controller = "Auth", action = "Register" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Post}/{action=Index}/{id?}");
            });
        }
    }
}
