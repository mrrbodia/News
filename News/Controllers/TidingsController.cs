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
            return View(news);
        }

        [HttpPost]
        [Authorize(Roles = "Filler")]
        public void Create(TidingsViewModel tiding)
        {
            var model = AutoMapper.Mapper.Map<Tidings>(tiding);
            tidingManager.Create(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Update(TidingsViewModel tiding)
        {
            var model = AutoMapper.Mapper.Map<Tidings>(tiding);
            tidingManager.Update(model);
        }
    }
}
