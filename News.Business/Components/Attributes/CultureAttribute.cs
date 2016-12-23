using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace News.Business.Components.Attributes
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string culture = null;

            var cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            if (cultureCookie != null)
                culture = cultureCookie.Value;
            else
                culture = "en";

            List<string> cultures = new List<string>() { "ru", "en", "uk" };
            if (!cultures.Contains(culture))
            {
                culture = "ru";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}
