using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace News.App_Start
{
    public class FlexiPageRouteConfig
    {
        public static FlexiPageRouteConfig Current
        {
            get
            {
                return new FlexiPageRouteConfig();
            }
        }

        public virtual void RegisterFlexiPage(string controllerName, string routeName, string pageUrl, string action)
        {
            var routes = RouteTable.Routes;
            routes.MapRoute(
             name: routeName,
             url: "{url}",
             defaults: new { controller = controllerName, action = "Index", url = UrlParameter.Optional }
           );
        }
    }
}