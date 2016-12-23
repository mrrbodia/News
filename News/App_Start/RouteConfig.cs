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
             name: "ShowXml",
             url: "xml/{id}",
                defaults: new { controller = "Tidings", action = "Xml", id = UrlParameter.Optional }
           );

            routes.MapRoute(
             name: "Tiding",
             url: "tiding/{id}",
                defaults: new { controller = "Tidings", action = "Tiding", id = UrlParameter.Optional }
           );

            routes.MapRoute(
             name: "Admin",
             url: "admin",
                defaults: new { controller = "Admin", action = "Admin" }
           );

            routes.MapRoute(
             name: "FlexiPage",
             url: "admin/flexipage",
                defaults: new { controller = "Admin", action = "CreateFlexiPage" }
           );

            routes.MapRoute(
             name: "Register",
             url: "register",
                defaults: new { controller = "User", action = "Register" }
            );

            routes.MapRoute(
             name: "Home",
             url: "",
                defaults: new { controller = "Tidings", action = "List" }
           );

            routes.MapRoute(
             name: "PagesList",
             url: "PagesList",
                defaults: new { controller = "Pages", action = "PagesList" }
            );

            routes.MapRoute(
             name: "CreatePage",
             url: "CreatePage",
                defaults: new { controller = "Pages", action = "CreatePage" }
            );

            routes.MapRoute(
             name: "EditPage",
             url: "EditPage",
                defaults: new { controller = "Pages", action = "EditPage" }
            );

            routes.MapRoute(
             name: "CreateContentBlock",
             url: "CreateContentBlock",
                defaults: new { controller = "ContentBlocks", action = "CreateContentBlock" }
            );
            
            routes.MapRoute(
             name: "ContentBlocksList",
             url: "ContentBlocksList",
                defaults: new { controller = "ContentBlocks", action = "ContentBlocksList" }
            );   

            routes.MapRoute(
             name: "Pages",
             url: "{*url}",
                defaults: new { controller = "Page", action = "Page" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}