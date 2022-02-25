using AssignmentFPTBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AssignmentFPTBook.Controllers
{
    public class AdminAccountController : Controller
    {
        private FPTBookStoreDbContext db = new FPTBookStoreDbContext();

        // GET: AdminAccount
        public ActionResult Index()
        {
            if (Session["UserName"] == Session["UserName"] && Session["Admin"] != null)
            {
                return View();
            }
            return View("Error");
        }

        public ActionResult UpdateInfor()
        {
            var admin = Session["Admin"];
            var user = Session["Username"];

            if (admin == null || user != null)
            {
                return View("Error");
            }

            Account objAccount = db.Accounts.ToList().Find(a => a.Username.Equals(admin));

            if (objAccount == null)
            {
                return HttpNotFound();
            }
            return View(objAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInfor(Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Attach(account);
                db.Entry(account).Property(a => a.Fullname).IsModified = true;
                db.Entry(account).Property(a => a.Email).IsModified = true;
                db.Entry(account).Property(a => a.Phone).IsModified = true;
                db.Entry(account).Property(a => a.Address).IsModified = true;

                db.SaveChanges();

                Response.Write("<script>alert('Update information success!');window.location='/AdminAccount';</script>");
            }

            return View(account);
        }

        public ActionResult ViewUserList()
        {
            if (Session["UserName"] == Session["UserName"] && Session["Admin"] != null)
            {
                return View(db.Accounts.ToList().OrderByDescending(a => a.State));
            }
            return View("Error");
        }

        public ActionResult DetailUser(string id)
        {
            if (Session["UserName"] == Session["UserName"] && Session["Admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Account user = db.Accounts.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailUser(Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Attach(account);
                db.Entry(account).Property(e => e.State).IsModified = true;

                db.SaveChanges();


                return RedirectToAction("ViewUserList");
            }
            return View(account);
        }
    }
}