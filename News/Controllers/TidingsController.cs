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
using News.Filters;

namespace News.Controllers
{   
    [Culture]
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
            return File(Encoding.Default.GetBytes(xml), "text/xml", name + ".xml");
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
            tiding.PublishData = DateTime.Now;
            tiding.AuthorId = User.Identity.Name;

            if (User.Identity.Name != tiding.AuthorId && !User.IsInRole("Admin"))
            {
                throw new HttpException(403, "Доступ заборонено");
            }
            if (!ModelState.IsValid)
            {
                return View(tiding);
            }
            var model = AutoMapper.Mapper.Map<Tidings>(tiding);
            tidingManager.Create(model);
            return RedirectToRoute("Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Filler")]
        public ActionResult Update(TidingsViewModel tiding)
        {
            tiding.PublishData = DateTime.Now;

            if (User.Identity.Name != tiding.AuthorId && !User.IsInRole("Admin"))
            {
                throw new HttpException(403, "Доступ заборонено");
            }
            if (!ModelState.IsValid)
            {
                return View(tiding);
            }
            var model = AutoMapper.Mapper.Map<Tidings>(tiding);
            tidingManager.Update(model);
            return RedirectToRoute("Home");
        }

        [HttpGet]
        public ActionResult Tiding(string id)
        {
            var model = AutoMapper.Mapper.Map<TidingsViewModel>(tidingManager.Get(id));
            return View(model);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var news = tidingManager.GetList().OrderByDescending(x => x.PublishData).ToList();
            tidingManager.AddLuceneIndex(news);

            return View(AutoMapper.Mapper.Map<IList<TidingsViewModel>>(news));
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult SearchForNews(string key)
        {
            var list = tidingManager.Search(key);
            return Json(list);
        }
    }
}
