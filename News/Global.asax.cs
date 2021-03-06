﻿using System.Configuration;
using System.Web.Http.WebHost;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using News.App_Start;

namespace News
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AutofacConfig.RegisterDependencies();
            AutomapperConfig.RegisterMaps();
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.MigrateDatabase(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}