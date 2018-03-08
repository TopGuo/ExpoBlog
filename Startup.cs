using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExpoBlog.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pomelo.AspNetCore.Localization;

namespace ExpoBlog {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            var con = Configuration.GetSection ("Database") ["ConnectionString"];
            services.AddDbContext<BlogContext> (option => option.UseMySql (con));

            // services.AddBlobStorage()
            //     .AddEntityFrameworkStorage<BlogContext>()
            //     .AddSessionUploadAuthorization();


            services.AddSmartCookies();

            services.AddMemoryCache();
            services.AddSession(x => x.IdleTimeout = TimeSpan.FromMinutes(20));

            services.AddBlobStorage()
                .AddEntityFrameworkStorage<BlogContext>()
                .AddSessionUploadAuthorization();

            services.AddPomeloLocalization(x =>
            {
                x.AddCulture(new string[] { "zh", "zh-CN", "zh-Hans", "zh-Hans-CN", "zh-cn" }, new JsonLocalizedStringStore(Path.Combine("Localization", "zh-CN.json")));
                x.AddCulture(new string[] { "en", "en-US", "en-GB" }, new JsonLocalizedStringStore(Path.Combine("Localization", "en-US.json")));
            });

            services.AddMvc()
                .AddMultiTemplateEngine()
                .AddCookieTemplateProvider();
            //services.AddMvc ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory) {

            loggerFactory.AddConsole(LogLevel.Error, true);

            app.UseStaticFiles();
            app.UseSession();
            app.UseBlobStorage("/assets/shared/scripts/jquery.codecomb.fileupload.js");
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();



            // if (env.IsDevelopment ()) {
            //     app.UseDeveloperExceptionPage ();
            // } else {
            //     app.UseExceptionHandler ("/Home/Error");
            // }

            // app.UseStaticFiles ();
            // app.UseMvc (routes => {
            //     routes.MapRoute (
            //         name: "default",
            //         template: "{controller=Home}/{action=Index}/{id?}");
            // });
        }
    }
}