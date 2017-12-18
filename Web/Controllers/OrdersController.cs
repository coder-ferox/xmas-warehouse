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
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            xmasDB db = new xmasDB();
            var orders = db.GetAllRequests().ToList();
            orders.ForEach(order => order.Toys = db.GetAllOrderedToys(order) as List<Toy>);
            Orders model = new Orders
            {
                EntityList = orders
            };
            return View(model);
        }

        public ActionResult Detail(string orderId)
        {
            if (orderId != null)
            {
                xmasDB db = new xmasDB();
                var order = db.GetRequest(orderId);
                Request model = new Request
                {
                    Id = order.Id,
                    Kid = order.Kid,
                    Status = order.Status,
                    Toys = order.Toys,
                    RequestDate = order.RequestDate
                };
                return View(model);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Update(string orderId)
        {
            if (orderId != null)
            {
                xmasDB db = new xmasDB();
                var order = db.GetRequest(orderId);
                Request model = new Request
                {
                    Id = order.Id,
                    Kid = order.Kid,
                    Status = order.Status,
                    Toys = db.GetAllOrderedToys(order) as List<Toy>,
                    RequestDate = order.RequestDate
                };
                return View(model);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Save(string id, RequestStatus requestStatus)
        {

            xmasDB db = new xmasDB();
            var order = db.UpdateRequest(id, requestStatus);
            return RedirectToAction("Detail", new { orderId = id });
        }
    }
}