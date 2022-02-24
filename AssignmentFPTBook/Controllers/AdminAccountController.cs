using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentFPTBook.Controllers
{
    public class AdminAccountController : Controller
    {
        // GET: AdminAccount
        public ActionResult Index()
        {
            if (Session["UserName"] == Session["UserName"] && Session["Admin"] != null)
            {
                return View();
            }
            return View("Error");
        }
    }
}