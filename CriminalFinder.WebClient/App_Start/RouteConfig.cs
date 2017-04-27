using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CriminalFinder.WebClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "criminal",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Criminal", action = "GetCriminals", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "criminalDetail",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Criminal", action = "GetCriminal", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "criminalSearch",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Criminal", action = "SearchCriminal" }
            );
            routes.MapRoute(
                name: "Email",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );
        }
    }
}
