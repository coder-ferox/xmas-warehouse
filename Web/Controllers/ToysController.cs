using GestioneLetterine.Classes;
using Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xmasDB = GestioneLetterine.Classes.MongoDB;

namespace Web.Controllers
{
    public class ToysController : Controller
    {
        public ActionResult Index()
        {
            xmasDB db = new xmasDB();
            var toys = db.GetAllToys().ToList();
            Toys model = new Toys
            {
                EntityList = toys
            };
            return View(model);
        }

    }
}