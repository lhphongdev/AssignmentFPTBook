using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentFPTBook.Models;

namespace AssignmentFPTBook.Controllers
{
    public class OrdersController : Controller
    {
        private FPTBookStoreDbContext db = new FPTBookStoreDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                var orders = db.Orders.Include(o => o.Account);
                return View(orders.ToList().OrderByDescending(o => o.OrderDate));
            }
            return View("Error");
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Order order = db.Orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Attach(order);
                db.Entry(order).Property(e => e.OrderStatus).IsModified = true;

                _ = db.SaveChanges();

                return RedirectToAction("Index");
            }
            return Content("<script>alert('Quantity is larger than our stock');window.location.replace('/');</script>");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
