using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentFinalProject.Models;
using System.Web.Security;

namespace StudentFinalProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using(var context = new firstEntities())
            {
                bool isValid = context.users.Any(x => x.username == model.username && x.password == model.password);
                if(isValid)
                {   
                    FormsAuthentication.SetAuthCookie(model.username,false);
                    return RedirectToAction("Index","Registration");
                }
                ModelState.AddModelError("", "Invalid username and password");
            }
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(user model)
        {
            using (var context = new firstEntities())
            {
                context.users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}