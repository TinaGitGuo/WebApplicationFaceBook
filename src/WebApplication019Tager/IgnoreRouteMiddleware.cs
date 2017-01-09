using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace WebApplication019Tager
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class IgnoreClientRoutes

    {
        private readonly RequestDelegate _next;
        private List<string> _baseRoutes;

        //base routes correcpond to Index actions of MVC controllers
        public IgnoreClientRoutes(RequestDelegate next, List<string> baseRoutes)
        {
            
            //List<string> baseRoutes;
            _next = next;
            _baseRoutes = baseRoutes;

        }//ctor


        public async Task Invoke(HttpContext context)
        {
            await Task.Run(() => {

                var path = context.Request.Path;

                foreach (var route in _baseRoutes)
                {
                    //Regex pattern = new Regex($"({route}).");
                    Regex pattern = new Regex($"{route}");
                    if (pattern.IsMatch(path))
                    {
                        //END RESPONSE HERE

                        return;

                    }

                }

                _next(context);

            });



        }//Invoke()
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class RouteMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseRouteMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<IgnoreRouteMiddleware>();
    //    }
    //}
}

//private readonly RequestDelegate _next;

//        public IgnoreRouteMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public Task Invoke(HttpContext httpContext)
//        {

//            return _next(httpContext);
//        }
//public class IgnoreClientRoutes
//{
//    private readonly RequestDelegate _next;
//    private List<string> _baseRoutes;

//    //base routes correcpond to Index actions of MVC controllers
//    public IgnoreClientRoutes(RequestDelegate next, List<string> baseRoutes)
//    {
//        _next = next;
//        _baseRoutes = baseRoutes;

//    }//ctor


//    public async Task Invoke(HttpContext context)
//    {
//        await Task.Run(() => {

//            var path = context.Request.Path;

//            foreach (var route in _baseRoutes)
//            {
//                Regex pattern = new Regex($"({route}).");
//                if (pattern.IsMatch(path))
//                {
//                    //END RESPONSE HERE

//                    return;

//                }

//            }

//            _next(context);

//        });



//    }//Invoke()


//}//class 