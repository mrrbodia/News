using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Business.Components.Managers;
using News.Business.ViewModels;
using News.Business.Models;

namespace News.Controllers
{
    public class TidingsController : Controller
    {
        private readonly TidingManager tidingManager;

        public TidingsController(TidingManager tidingManager)
        {
            this.tidingManager = tidingManager;
        }

        //
        // GET: /Tidings/

        [HttpGet]
        public ActionResult List()
        {
            var news = tidingManager.GetList();
            var model = AutoMapper.Mapper.Map<IList<TidingsViewModel>>(news);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Filler")]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Filler")]
        public ActionResult Create(TidingsViewModel tiding)
        {
            var model = AutoMapper.Mapper.Map<Tidings>(tiding);
            model.PublishData = DateTime.Now;
            tidingManager.Create(model);

            tidingManager.Serialize<Tidings>(model);
            return RedirectToRoute("Home");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Update()
        {
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(TidingsViewModel tiding)
        {
            var model = AutoMapper.Mapper.Map<Tidings>(tiding);
            model.PublishData = DateTime.Now;
            tidingManager.Update(model);
            return RedirectToRoute("Home");
        }
    }
}
