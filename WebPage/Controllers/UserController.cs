using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPage.Models;

namespace WebPage.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Login(int id)
        {
            DatabaseContextPage db = new DatabaseContextPage();
            var entity = db.UserEntities.Where(x => x.UserId == id).FirstOrDefault();
            if (entity != null)
            {
                ViewBag.Email = entity.Email;
                return View();
            }
            return RedirectToAction("Forbidden");
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Forbidden()
        {
            return View();
        }
    }
}