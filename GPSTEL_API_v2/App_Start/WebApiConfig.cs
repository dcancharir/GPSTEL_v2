using GPSTEL_API_v2.App_Start;
using GPSTEL_API_v2.JWTClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GPSTEL_API_v2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            var cors = new EnableCorsAttribute(origins: "*", headers: "*", methods: "*");
            //config.EnableCors(new AccessPolicyCors());
            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new TokenValidationHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
