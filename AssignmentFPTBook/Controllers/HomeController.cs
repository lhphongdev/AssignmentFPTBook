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

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult BookDetail(string id)
        {
            var books = db.Books.ToList().Find(a => a.BookID == id);
            return View(books);
        }

        public ActionResult CategoryView(string id)
        {
            var books = db.Books.ToList().Where(a => a.CategoryID == id);
            return View(books);
        }

        public ActionResult Search(string Search)
        {
            ViewBag.Search = Search;
            var books = db.Books.ToList().Where(s => s.BookName.ToUpper().Contains(Search.ToUpper()) ||
                 s.Author.AuthorName.ToUpper().Contains(Search.ToUpper()) ||
                 s.Category.CategoryName.ToUpper().Contains(Search.ToUpper()));

            return View(books);

        }
    }
}