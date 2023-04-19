using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Http.Common;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace StudentAppln4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           var settings= config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.EnableCors();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
