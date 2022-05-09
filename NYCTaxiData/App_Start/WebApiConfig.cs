using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NYCTaxiFHVData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var cors = new EnableCorsAttribute("*", "*", "*");
           // config.EnableCors();
            ConfigureFormatters(config);
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void ConfigureFormatters(HttpConfiguration config)
        {
            config.Formatters.Clear();
            var jsonFormatter = new JsonMediaTypeFormatter();
            var settings = jsonFormatter.SerializerSettings;
            settings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            settings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            settings.DateFormatString = "MM/dd/yyyy hh:mm:ss tt";
            config.Formatters.Add(jsonFormatter);
        }
    }
}
