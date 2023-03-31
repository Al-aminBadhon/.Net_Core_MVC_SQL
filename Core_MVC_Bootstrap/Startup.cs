using App.BLL.ServiceContracts;
using App.BLL.Services;
using App.DAL.Data;
using App.DAL.Repositories;
using App.DAL.RepositoryContracts;
using App.Home.FileUploadService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_MVC_Bootstrap
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

            

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(options =>
                 {
                     options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                     options.LoginPath = "/Login/Login";
                     options.AccessDeniedPath = "/Login/Login"; ;
                 }
                );
            services.AddSession(
                obj =>
                {
                    obj.IdleTimeout = TimeSpan.FromMinutes(10);
                    obj.Cookie.HttpOnly = true;
                    obj.Cookie.IsEssential = true;
                });

            services.AddControllersWithViews();
            //services.AddHttpContextAccessor();

            services.AddDbContext<MHDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));


            services.AddTransient<IDirectorsService, DirectorsService>();
            services.AddTransient<IDirectorsRepository, DirectorsRepository>();

            services.AddTransient<IGalleryService, GalleryService>();
            services.AddTransient<IGalleryRepository, GalleryRepository>();

            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<App.DAL.Utilities.AppUser>();

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
            }
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Scripts")),
                RequestPath = "/Scripts"
            });

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
