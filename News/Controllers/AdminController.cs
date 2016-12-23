using News.App_Start;
using News.Business.Components.Managers;
using News.Business.Models;
using News.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager userManager;

        private readonly RoleManager roleManager;

        public AdminController(UserManager userManager, RoleManager roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public ActionResult Admin()
        {
            var mail = new Mailer();
            Mailer.Current.SendMessage();

            var model = new AdminDataViewModel();
            model.Users = userManager.GetList();
            model.Roles = roleManager.GetList();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateNewRole(string roleName)
        {
            try
            {
                Role roleAdmin = new Role();
                roleAdmin.Name = roleName;
                roleManager.Create(roleAdmin);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult DeleteRole(string roleId)
        {
            try
            {
                roleManager.Delete(roleId);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult UpdateUserRole(string userId, string roleId)
        {
            try
            {
                var user = userManager.Get(userId);
                var role = roleManager.Get(roleId);
                user.Role = role;
                userManager.Update(user);

                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }

        [HttpGet]
        public ActionResult CreateFlexiPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFlexiPage(FlexiPageDataModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            FlexiPageRouteConfig.Current.RegisterFlexiPage("FlexiPages", model.Name, model.Url, "Index");
            return Json(true);
        }
    }
}