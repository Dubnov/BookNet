﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookNet.Controllers
{    
    public class AdminController : Controller
    {
        [Authorization(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (HttpContext.Session["userAuth"] != null && HttpContext.Session["userAuth"].ToString() == Roles.Admin.ToString())
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string username = form["Username"] ?? string.Empty;
                string password = form["Password"] ?? string.Empty;

                if (username == Properties.Settings.Default.AdminUser &&
                    password == Properties.Settings.Default.AdminPass)
                {
                    HttpContext.Session.Add("userAuth", Roles.Admin.ToString());
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "The username or password was incorrect.");
            return View();
        }
    }
}