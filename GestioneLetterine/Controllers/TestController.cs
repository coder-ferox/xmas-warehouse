using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XmasMongoDB = GestioneLetterine.Models.MongoDB;
using GestioneLetterine.Models;

namespace GestioneLetterine.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult GetToys()
        {
            XmasMongoDB db = new XmasMongoDB();
            var toys = db.GetAllToysInWarehouse();
            Toys model = new Toys();
            model.EntityList = toys.ToList();
            return View(model);

        }
    }
}