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
    public class CategoriesController : Controller
    {
        private FPTBookStoreDbContext db = new FPTBookStoreDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                return View(db.Categories.ToList().OrderBy(c => c.CategoryID));
            }
            return View("Error");
        }

        // GET: Categories/Details/5
        public ActionResult Details(string id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = db.Categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            return View("Error");
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return View("Error");
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = db.Categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            return View("Error");

        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = db.Categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            return View("Error");
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
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
