using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RecruitApp.Handler;
using RecruitApp.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;


namespace RecruitApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            //// Web API configuration and services Applying the attribute at the
            //// Global level for the Web Api
            var cors = new EnableCorsAttribute("*", "*", "*");

            //// To improve performance have the Browser cache the Preflight
            //// Request permission Preflight response will now contain the
            //// Access-Control-Max-Age: <delta-seconds> Header
            cors.PreflightMaxAge = 600;
            config.EnableCors(cors);
            cors.ExposedHeaders.Add("Content-Disposition");
            //// Use Camel Casing Property Names for JSON and use Json.Net for serialization
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "uiapi/{controller}/{action}/{id}", defaults: new { id = RouteParameter.Optional });

            config.Services.Replace(typeof(IExceptionHandler), new RecruitExceptionHandler());

            // Add Application Insights Exception Logger 
            config.Services.Add(typeof(IExceptionLogger), new RecruitAppErrorLogger());

            // Add authorize attribute at global level so that it need not be initialized at controller level
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}
