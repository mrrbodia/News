using News.Business.Components.Managers;
using News.Business.Models;
using News.Business.ViewModels;
using News.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    [Culture]
    public class CommentController : Controller
    {
        CommentManager commentManager;
        UserManager userManager;

        public CommentController(CommentManager commentManager, UserManager userManager)
        {
            this.commentManager = commentManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public ActionResult AddComment(CommentViewModel commentModel)
        {
            if (String.IsNullOrEmpty(commentModel.TidingId))
            {
                return RedirectToRoute("eventDetails");
            }
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = userManager.GetByEmail(User.Identity.Name);
                commentModel.AuthorId = user.Id;
                commentModel.AuthorName = user.Email;
                commentModel.PostingTime = DateTime.Now;
                var comment = AutoMapper.Mapper.Map<Comment>(commentModel);
                commentManager.Create(comment);
            }
            return RedirectToRoute("Tiding", new { id = commentModel.TidingId });
        }
    }
}
