using AssignmentFPTBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentFPTBook.Controllers
{
    public class HomeController : Controller
    {
        private FPTBookStoreDbContext db = new FPTBookStoreDbContext();
        public ActionResult Index()
        {
            var books = db.Books.ToList();
            return View(books);
        }

        public ActionResult BookDetail(string id)
        {
            var books = db.Books.ToList().Find(a => a.BookID == id);
            return View(books);
        }

        //public ActionResult CategoryView(string id)
        //{
        //    var books = db.Books.ToList().FirstOrDefault(a => a.CategoryID == id);
        //    return View(books);
        //}

        //public ActionResult AuthorView(string id)
        //{
        //    var books = db.Books.ToList().Find(a => a.AuthorID == id);
        //    return View(books);
        //}
    }
}