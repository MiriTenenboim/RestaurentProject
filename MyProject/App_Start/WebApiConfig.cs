using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Web API configuration and services
            config.MapHttpAttributeRoutes();

            // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{functionName}/{id}/{code}",
                defaults: new { id = RouteParameter.Optional, code = RouteParameter.Optional }
            );
        }
    }
}
