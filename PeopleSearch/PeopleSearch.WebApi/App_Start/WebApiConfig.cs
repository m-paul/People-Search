﻿using Newtonsoft.Json.Serialization;
using PeopleSearch.DataAccess;
using PeopleSearch.WebApi.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace PeopleSearch.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Register unity container
            var container = new UnityContainer();
            container.RegisterType<IPersonManager, PersonManager>();
            container.RegisterType<IPeopleSearchDAL, PeopleSearchDAL>();
            config.DependencyResolver = new UnityResolver(container);

            // Enable cross-origin requests from the web client
            var origins = ConfigurationManager.AppSettings["WebClientCorsAddress"];
            var corsAttr = new EnableCorsAttribute(origins, "*", "*");
            config.EnableCors(corsAttr);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Transform json to camelCase
            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
