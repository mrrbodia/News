using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Business.Components.Managers;
using News.Business.ViewModels;
using News.Business.Models;
using News.Business.Components;
using News.Business.Providers;
using System.Text;

namespace News.Controllers
{
    public class TidingsController : Controller
    {
        private readonly TidingManager tidingManager;

        public TidingsController(TidingManager tidingManager)
        {
            this.tidingManager = tidingManager;
        }

        [HttpGet]
        public ActionResult List()
        {
            var news = tidingManager.GetList();

            var model = AutoMapper.Mapper.Map<IList<TidingsViewModel>>(news)
                .OrderByDescending(x => x.PublishData).ToList();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Xml()
        {
            var news = tidingManager.GetList();
            var xml = XmlProvider<Tidings>.Serialize(news);
            var name = "news";
            return File(Encoding.Default.GetBytes(xml), "text/xml", name + ".xml");;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Filler")]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Filler")]
        public ActionResult Create(TidingsViewModel tiding)
        {
            if (User.Identity.Name != tiding.AuthorId && !User.IsInRole("Admin"))
            {
                throw new HttpException(403, "Доступ заборонено");
            }
            if (!ModelState.IsValid)
            {
                return View(tiding);
            }
            var model = AutoMapper.Mapper.Map<Tidings>(tiding);
            model.PublishData = DateTime.Now;
            model.AuthorId = User.Identity.Name;
            tidingManager.Create(model);
            return RedirectToRoute("Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Filler")]
        public ActionResult Update(TidingsViewModel tiding)
        {
            if (User.Identity.Name != tiding.AuthorId && !User.IsInRole("Admin"))
            {
                throw new HttpException(403, "Доступ заборонено");
            }
            if (!ModelState.IsValid)
            {
                return View(tiding);
            }
            var model = AutoMapper.Mapper.Map<Tidings>(tiding);
            model.PublishData = DateTime.Now;
            tidingManager.Update(model);
            return RedirectToRoute("Home");
        }
    }
}
