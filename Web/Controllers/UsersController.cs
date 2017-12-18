using GestioneLetterine.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xmasDB = GestioneLetterine.Classes.MongoDB;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            xmasDB db = new xmasDB();
            var usr = db.GetUser(user);
            if (usr != null)
            {
                Session["Email"] = usr.Email.ToString();
                Session["UserID"] = usr.Id.ToString();
                Session["Username"] = usr.Username.ToString();
                if (usr.IsAdmin)
                {
                    Session["IsAdmin"] = usr.IsAdmin.ToString();
                }
                return RedirectToAction($"../Home");
            }
            else
            {
                ModelState.AddModelError("", "Email or password incorrect");
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (Session["UserID"] != null)
            {
                Session.Clear();
                return RedirectToAction("Logout");
            }
            return View();
        }

    }
}