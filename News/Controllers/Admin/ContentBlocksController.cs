using AutoMapper;
using News.Business.Components.Managers;
using News.Business.Models.Admin;
using News.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers.Admin
{
    public class ContentBlocksController : Controller
    {
        ContentBlockManager contentBlockManager;
        PageManager pageManager;

        public ContentBlocksController(ContentBlockManager contentBlockManager, PageManager pageManager)
        {
            this.contentBlockManager = contentBlockManager;
            this.pageManager = pageManager;
        }

        [HttpGet]
        public ActionResult ContentBlocksList(int page)
        {
            var list = contentBlockManager.GetList();
            //ViewData["Page"] = page;
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateContentBlock()
        {
            var model = new ContentBlockDesignModel(Guid.NewGuid());
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult EditContentBlock(string id)
        {
            var model = contentBlockManager.Get(id);

            var mapped = Mapper.Map<ContentBlockDesignModel>(model);

            return PartialView("CreateContentBlock", mapped);
        }

        [HttpGet]
        public ActionResult DeleteContentBlock(string id)
        {
            contentBlockManager.Delete(id);
            return RedirectToRoute("ContentBlockList", new { page = 0 });
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CreateContentBlock(ContentBlockDesignModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }

            var mapped = Mapper.Map<ContentBlock>(model);

            contentBlockManager.Create(mapped);

            return Json(true);
        }
    }
}