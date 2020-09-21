using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace TestASPCoreOnGitHub
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(); /// to add mvc application patern 
            services.AddControllersWithViews(); // to add controller and views 
                                                // services.AddRazorPages();  // to add htmlcss files (view)
                                                // services.AddControllers();  /// to add webapi use addcontrollers pattern only

            #if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
            #endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // to add new custome middle ware
            //
            /* app.Use(async (context, next) =>
             {

                 await context.Response.WriteAsync("Env. Name :" + env.EnvironmentName + "\n");

                 await context.Response.WriteAsync("Hello from my first Middle ware (M1)" + "\n");
                 // to go to next middle ware we should call next method here
                 await next();


                 await context.Response.WriteAsync("Hello from my first Middle ware (M1) response " + "\n");

             });





             // by this code it will not going to next middle ware cause we did not call next method
             app.Use(async (context, next) =>
             {

                 await context.Response.WriteAsync("Hello from my seconed Middle ware (M2)" + "\n");
                 //to go to next middle ware we should call next method here
                 await next();

                 await context.Response.WriteAsync("Hello from my seconed Middle ware (M2) response " + "\n");
             });


             app.Use(async (context, next) =>
             {

                 await context.Response.WriteAsync("Hello from my Third Middle ware (M3)" + "\n");
                 await next();


             });

             */



            // to tell the application use static files in default folder "wwwroot" in pipline 
            // you should use this middleware called "usestaticfiles"

            app.UseStaticFiles();



            // to tell application use static files but in custome folder like mystaticfiles
            // you should use staticfilesoptions and give fileprovider , requestpath
            app.UseStaticFiles(
                new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
                    RequestPath = "/MyStaticFiles"

                });



            // so before using endpoint you should userouting or will throw this exception
            /// Please add EndpointRoutingMiddleware by calling 'IApplicationBuilder.UseRouting

            /// the order of using middle ware here is matter it mean if you call endpoint before routing will give you an excption too
            app.UseRouting();

            // map url (your route ) to particular resource 
            app.UseEndpoints(endpoints =>
            {

                /// here the maping 
                /// the defualt  url is "/" means the domain
                /// 
                ///// mapget will handle only the get request 
                /// map method will handel all requests 
                endpoints.MapGet("/", async context =>
                {

                    if (env.IsDevelopment())
                    {
                        await context.Response.WriteAsync("Hello from Dev. Env. \n");
                    }
                    else if (env.IsProduction())
                    {
                        await context.Response.WriteAsync("Hello from  Prod. Env. \n");
                    }
                    else if (env.IsStaging())
                    {
                        await context.Response.WriteAsync("Hello from  Stag. Env. \n");
                    }
                    else
                    {
                        await context.Response.WriteAsync("Hello from Custome Env. \n");
                    }


                });


                endpoints.MapGet("/Ibrahim", async context =>
                {
                    await context.Response.WriteAsync("Hello Ibrahim!" + "\n");
                });



                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });



        }
    }
}
