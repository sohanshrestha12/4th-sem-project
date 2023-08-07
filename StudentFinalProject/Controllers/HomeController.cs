using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentFinalProject.Models;

namespace StudentFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private firstEntities db = new firstEntities();
        public ActionResult Index()
        {
            return View(db.teachers.ToList()) ;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}