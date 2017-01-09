using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace WebApplication019Tager
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {


            //var trackPackageRouteHandler = new RouteHandler(context =>
            //{
            //    var routeValues = context.GetRouteData().Values;
            //    return context.Response.WriteAsync(
            //        $"Hello! Route values: {string.Join(", ", routeValues)}");
            //});
            var trackPackageRouteHandler = new RouteHandler(context =>
            {                 
                return context.Response.WriteAsync(
                    "Hello! 404 ");
            });

            var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);

            //routeBuilder.MapRoute(
            //    "Track Package Route",
            //    "Home/{operation:regex(^track|Index|detonate$)}/{id:int}");
            // when regex(^track|Index|detonate$) is true,return "Hello! 404. such as http://localhost:3980/Home/Index; Otherwise, the following 'default' route is executed",such as http://localhost:3980/Home/About
            routeBuilder.MapRoute(
                "Ignore Route",
                "Home/{operation:regex(^track|Index|detonate$)}/{id?}");

            //routeBuilder.MapGet("hello/{name}", context =>
            //{
            //    var name = context.GetRouteValue("name");
            //    // This is the route handler when HTTP GET "hello/<anything>"  matches
            //    // To match HTTP GET "hello/<anything>/<anything>,
            //    // use routeBuilder.MapGet("hello/{*name}"
            //    return context.Response.WriteAsync($"Hi, {name}!");
            //});

            var routess = routeBuilder.Build();
            app.UseRouter(routess);




            //app.UseMiddleware<IgnoreClientRoutes>(new List<string>() { "track", "Index", "detonate" });
            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //"Track Package Route",
            //"Home/{operation:regex(^track|Create|detonate$)}");
            //     //return context.Response.WriteAsync($"Hi,  !");

            // });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=About}/{id?}");
            });
        }
    }
}
