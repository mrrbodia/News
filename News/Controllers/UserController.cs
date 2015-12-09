using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Business.ViewModels;
using News.Business.Components.Managers;
using System.Web.Security;
using News.Business.Models;
using News.Business.Components;

namespace News.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager userManager;

        private readonly RoleManager roleManager;

        public UserController(UserManager userManager, RoleManager roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            //SetNewRole();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (!userManager.IsRoleAssigned(user.Email, user.Password))
            {
                ModelState.AddModelError("Email", "Дані не коректні");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                if (User.IsInRole("Admin"))
                {
                    return RedirectToRoute("Home");//adminPage
                }

                return RedirectToRoute("Home");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Home");
        }

        public void SetNewRole()
        {
            User admin = new User();
            admin.Email = "Admin@gmail.com";
            admin.PasswordSalt = HashDecoder.GenarateSalt();
            admin.Password = HashDecoder.ComputeHash("IAdmin", admin.PasswordSalt);

            Role roleAdmin = new Role();
            roleAdmin.Name = "Admin";
            roleManager.Create(roleAdmin);

            admin.Role = roleAdmin;
            userManager.Create(admin);
        }
    }
}
