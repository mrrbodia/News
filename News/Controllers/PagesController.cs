using AutoMapper;
using News.Business.Components.Managers;
using News.Business.Models;
using News.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using News.Business;

namespace News.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PagesController : Controller
    {
        ContentBlockManager contentBlockManager;
        PageManager pageManager;

        public PagesController(ContentBlockManager contentBlockManager, PageManager pageManager)
        {
            this.contentBlockManager = contentBlockManager;
            this.pageManager = pageManager;
        }

        [HttpGet]
        public ActionResult PagesList(int page)
        {
            var list = pageManager.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreatePage()
        {
            var model =  new PageDesignModel(Guid.NewGuid());
            model.ContentBlocksVariants = contentBlockManager.GetList();
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult EditPage(string id)
        {
            var model = pageManager.Get(id);

            var mapped = AutoMapper.Mapper.Map<Page>(model);

            return PartialView("CreatePage", mapped);
        }

        [HttpGet]
        public ActionResult DeletePage(string id)
        {
            pageManager.Delete(id);
            return RedirectToRoute("PageList");
        }

        [HttpPost]
        public ActionResult CreatePage(PageDesignModel model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            var mapped = Mapper.Map<Page>(model);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(model.ContentBlocks.Serialize());
            mapped.ContentBlocks = xml;

            pageManager.Create(mapped);
            return CreatePage();
        }
    }
}