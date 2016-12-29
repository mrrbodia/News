using News.Business.Components.Managers;
using News.Business.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using News.Business;

namespace News.Controllers
{
    public class PageController : Controller
    {
        ContentBlockManager contentBlockManager;
        PageManager pageManager;

        public PageController(ContentBlockManager contentBlockManager, PageManager pageManager)
        {
            this.contentBlockManager = contentBlockManager;
            this.pageManager = pageManager;
        }

        //[HttpGet]
        //public ActionResult Post(string id)
        //{
        //    var post = postsManager.GetById(id);

        //    if (post == null)
        //    {
        //        return RedirectToRoute("Error404");
        //    }

        //    return View(post);
        //}

        //[HttpPost]
        //public ActionResult AddPostComment(string PostId, string UserId, string Content)
        //{
        //    if (String.IsNullOrWhiteSpace(Content) || Content.Length > 500)
        //    {
        //        return RedirectToAction("Post", new { id = PostId });
        //    }

        //    var comment = Dependecies.Resolver.GetInstance<PostComment>();
        //    comment.UserId = UserId;
        //    comment.PostId = PostId;
        //    Content = "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee";
        //    comment.Content = Content;

        //    commentsManager.CreateOrUpdate(comment);

        //    return RedirectToAction("Post", new { id = PostId });
        //}

        [HttpGet]
        public ActionResult Page(string url)
        {
            var page = pageManager.GetByField("Url", url);

            if (page == null)
            {
                return RedirectToRoute("Error404");
            }
            ViewBag.Title = page.Title;

            var blockIds = page.ContentBlocks.DeserializeAs<List<string>>();
            var blocks = new List<ContentBlock>();

            foreach (var id in blockIds)
            {
                var block = contentBlockManager.Get(id);

                if (block.Type == ContentBlock.BlockType.Redirect)
                {
                    return Redirect(block.Content);
                }

                blocks.Add(block);
            }

            return View(blocks);
        }
    }
}
