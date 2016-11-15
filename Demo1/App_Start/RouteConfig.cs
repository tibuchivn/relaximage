using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default2",
                url: "lastest/{action}/{id}",
                defaults: new { controller = "lasted", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default3",
                url: "clip/{action}/{id}",
                defaults: new { controller = "clip", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}