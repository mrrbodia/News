﻿using System;
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
        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid && model.Password.Equals(model.RepeatPassword))
            {
                CreateNewUser(model.Email, model.Password);
            }
            return View(model);
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
                    return RedirectToRoute("Admin");//adminPage
                }
                if (User.IsInRole("Filler"))
                {
                    return RedirectToRoute("Home");
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
            admin.Email = "Filler2@gmail.com";
            admin.PasswordSalt = HashDecoder.GenarateSalt();
            admin.Password = HashDecoder.ComputeHash("IFiller", admin.PasswordSalt);

            Role roleAdmin = new Role();
            roleAdmin.Name = "Filler";
            roleManager.Create(roleAdmin);

            admin.Role = roleAdmin;
            userManager.Create(admin);
        }

        protected void CreateNewUser(string email, string password)
        {
            var user = new User();
            user.Email = email;
            user.PasswordSalt = HashDecoder.GenarateSalt();
            user.Password = HashDecoder.ComputeHash(password, user.PasswordSalt);

            var role = roleManager.GetRoleForName("Filler");
            user.Role = role;
            userManager.Create(user);
        }
    }
}
