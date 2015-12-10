using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace News
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "logIn",
             url: "login",
                defaults: new { controller = "User", action = "LogIn" }
           );

            routes.MapRoute(
             name: "LogOut",
             url: "logout",
                defaults: new { controller = "User", action = "LogOut" }
           );

            routes.MapRoute(
             name: "Home",
             url: "",
                defaults: new { controller = "Tidings", action = "List" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}