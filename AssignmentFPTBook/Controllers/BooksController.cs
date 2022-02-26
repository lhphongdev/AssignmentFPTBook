using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentFPTBook.Models;

namespace AssignmentFPTBook.Controllers
{
    public class BooksController : Controller
    {
        private FPTBookStoreDbContext db = new FPTBookStoreDbContext();

        // GET: Books
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                var books = db.Books.Include(b => b.Author).Include(b => b.Category);
                return View(books.ToList());
            }
            return View("Error");
        }

        // GET: Books/Details/BookID
        public ActionResult Details(string id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book book = db.Books.Find(id);
                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(book);
            }
            return View("Error");
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName");
                ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
                return View();
            }
            return View("Error");
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                //book.Image = new byte[image.ContentLength];
                //image.InputStream.Read(book.Image, 0, image.ContentLength);
                string fileName = Path.GetFileName(image.FileName);
                string urlImage = Path.Combine(Server.MapPath("~/Image/"), fileName);
                image.SaveAs(urlImage);

                book.UrlImage = "~/Image/" + fileName;
            }


            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // GET: Books/Edit/BookID
        public ActionResult Edit(string id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book book = db.Books.Find(id);
                if (book == null)
                {
                    return HttpNotFound();
                }
                ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
                ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
                return View(book);
            }
            return View("Error");
        }

        // POST: Books/Edit/BookID
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,BookName,CategoryID,AuthorID,Quantity,Price,Image,ShortDesc,DetailDesc")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // GET: Books/Delete/BookID
        public ActionResult Delete(string id)
        {
            if (Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Book book = db.Books.Find(id);
                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(book);
            }
            return View("Error");
        }

        // POST: Books/Delete/BookID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
