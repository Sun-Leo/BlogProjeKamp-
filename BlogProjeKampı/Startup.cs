using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjeKampı
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));


            });
            services.AddMvc();
            services.AddAuthentication(

                CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                }

                );

            services.AddScoped<ICategoryDal, EFCategoryRepository>();
            services.AddScoped<ICategoryServices, CategoryManager>();

            services.AddScoped<IBlogDal, EFBlogRepository>();
            services.AddScoped<IBlogServices, BlogManager>();

            services.AddScoped<ICommentDal, EFCommentRepository>();
            services.AddScoped<ICommentServices, CommentManager>();

            services.AddScoped<IWriterDal, EFWriterRepository>();
            services.AddScoped<IWriterServices, WriterManager>();

            services.AddScoped<ICityDal, EFCityRepository>();
            services.AddScoped<ICityServices, CityManager>();

            services.AddScoped<INewsLetterDal, EFNewsLetterRepository>();
            services.AddScoped<INewsLetterServices, NewLetterManager>();

            services.AddScoped<IAboutDal, EFAboutRepository>();
            services.AddScoped<IAboutServices, AboutManager>();

            services.AddScoped<IContactDal, EFContactRepository>();
            services.AddScoped<IContactServices, ContactManager>();

            services.AddScoped<INatificationDal, EFNatificationRepository>();
            services.AddScoped<INatificationServices, NatificationManager>();

            services.AddScoped<IMessageDal, EFMessageRepository>();
            services.AddScoped<IMessageServices, MessageManager>();

            services.AddScoped<IMessage2Dal, EFMessage2Repository>();
            services.AddScoped<IMessage2Services, Message2Manager>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
             );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
