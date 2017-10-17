using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Knockout.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // CORS settings
            string origin = "*";
            EnableCorsAttribute cors = new EnableCorsAttribute(origin, "*", "GET,POST,PUT,DELETE");
            config.EnableCors(cors);

            // Formatter settings
            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            //config.Routes.MapHttpRoute(
            //    name: "Auth_Login",
            //    routeTemplate: "api/auth/login",
            //    defaults: new { controller = "auth", action = "login" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "Auth_Logout",
            //    routeTemplate: "api/auth/logout",
            //    defaults: new { controller = "auth", action = "logout" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "Auth_CheckAuth",
            //    routeTemplate: "api/auth/checkauth",
            //    defaults: new { controller = "auth", action = "checkAuth" }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi_Route",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
