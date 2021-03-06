﻿using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MovieStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieStore.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;

namespace MovieStore
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator>();
            services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:MovieStore:ConnectionString"]));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddIdentity<AppUser, IdentityRole>(opts => {

                opts.User.RequireUniqueEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";

                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddTransient<IMovieRepository, EFMovieRepository>();
            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.CookieHttpOnly = true;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseSession();
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "Empty",
                    template: "",
                    defaults: new { controller = "Account", action = "Login" }
                    );

                routes.MapRoute(
                    name: "Profile",
                    template: "{controller}/{action?}",
                    defaults: new { controller = "Profile", action = "Profile" });

                routes.MapRoute(
                    name: "Cart",
                    template: "Cart",
                    defaults: new { controller = "Cart", action = "ViewCart" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "GoToHomePage" }
                    );

                try
                {
                    AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
                }
                catch (AggregateException e)
                {

                }
               
            }
            );
            SeedData.EnsurePopulated(app);
        }
    }
}
