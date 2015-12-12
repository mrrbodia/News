using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Business.Components.Managers;
using News.Business.ViewModels;
using News.Business.Models;
using News.Business.Components;

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
            var xml = tidingManager.Serialize(news);
            return View(model);
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
            if (!ModelState.IsValid)
            {
                return RedirectToRoute("Home");
            }
            var model = AutoMapper.Mapper.Map<Tidings>(tiding);
            model.PublishData = DateTime.Now;
            model.AuthorId = User.Identity.Name;
            tidingManager.Create(model);
            return RedirectToRoute("Home");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Filler")]
        public ActionResult Update()
        {
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Filler")]
        public ActionResult Update(TidingsViewModel tiding)
        {
            var model = AutoMapper.Mapper.Map<Tidings>(tiding);
            model.PublishData = DateTime.Now;
            tidingManager.Update(model);
            return RedirectToRoute("Home");
        }
    }
}
