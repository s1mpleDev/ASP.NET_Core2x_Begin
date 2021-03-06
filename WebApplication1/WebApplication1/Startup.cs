﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            //app.Use(async (context, next) =>
            //{
            //   await context.Response.WriteAsync("Middleware 1 \n");
            //   await next.Invoke();
            //   await context.Response.WriteAsync("return Middleware 1 \n");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World! \n" + Configuration.GetSection("message").Value + "\n");
            //});
            // router default
            app.UseMvcWithDefaultRoute();
            app.UseMvc(router =>
            {
                router.MapRoute("trang-chu", "trang-chu", new
                {
                    Controller = "Home",
                    Action = "Index"
                });
                // new controller
                //router.MapRoute("product", "{controller=Product}/{action=index}/{id:int?}");

                //router.MapRoute("test01", "product/{id:int}", new
                //{
                //    Controller = "Product",
                //    Action = "Index"
                //});
                router.MapRoute("test02", "product/tranh-name-action/{name:alpha}", new
                {
                    Controller = "Product",
                    Action = "Version"
                });
                //router.MapRoute("test03", "{controller}/{action}/{id}", new
                //{
                //    Controller = "Product",
                //    Action = "Index"
                //}, new { 
                //    id = new IntRouteConstraint()
                //}); 
                router.MapRoute("test03", "product/{id}", new
                {
                    Controller = "Product",
                    Action = "Index"
                }, new { 
                    id = new IntRouteConstraint()
                });

                // router default
                router.MapRoute("default", "{controller=Home}/{action=index}/{id?}");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("false");
            });
        }
    }
}
