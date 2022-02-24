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
    public class AuthorsController : Controller
    {
        private FPTBookStoreDbContext db = new FPTBookStoreDbContext();

        // GET: Authors
        public ActionResult Index()
        {
            if (Session["UserName"] == Session["UserName"] && Session["Admin"] != null)
            {
                return View(db.Authors.ToList().OrderBy(a => a.AuthorID));
            }
            return View("Error");

        }

        // GET: Authors/Details/5
        public ActionResult Details(string id)
        {
            if (Session["UserName"] == Session["UserName"] && Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Author author = db.Authors.Find(id);
                if (author == null)
                {
                    return HttpNotFound();
                }
                return View(author);
            }
            return View("Error");


        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            if (Session["UserName"] == Session["UserName"] && Session["Admin"] != null)
            {
                return View();
            }
            return View("Error");
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorID,AuthorName,Description")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(string id)
        {

            if (Session["UserName"] == Session["UserName"] && Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Author author = db.Authors.Find(id);
                if (author == null)
                {
                    return HttpNotFound();
                }
                return View(author);
            }
            return View("Error");

        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorID,AuthorName,Description")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(string id)
        {

            if (Session["UserName"] == Session["UserName"] && Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Author author = db.Authors.Find(id);
                if (author == null)
                {
                    return HttpNotFound();
                }
                return View(author);
            }
            return View("Error");

        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
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
