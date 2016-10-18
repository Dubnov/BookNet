using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookNet.Controllers
{
    public class AdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Request.Cookies["admin"] != null && Request.Cookies["admin"].ToString() == "admin")
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
                    password == Properties.Settings.Default.AdminPas)s
                {
                    Request.Cookies.Add(new HttpCookie("admin", "admin"));
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "The username or password was incorrect.");
            return View();
        }
    }
}