using News.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class FlexiPagesController : Controller
    {
        public ActionResult Index(string url)
        {
            return View();
        }
    }
}