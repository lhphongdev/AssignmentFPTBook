using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentFPTBook.Models;

namespace AssignmentFPTBook.Controllers
{
    public class ShoppingCartController : Controller
    {
        public FPTBookStoreDbContext _db = new FPTBookStoreDbContext();

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;

        }

        public ActionResult AddtoCart(string id)
        {
            var pro = _db.Books.SingleOrDefault(s => s.BookID == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult UpdateQuantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            string id_pro = form["ID_Product"];
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult Delete(string id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.DeleteCart(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
            {
                Response.Write("<script>alert('Cart is empty');window.location='/'</script>");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public PartialViewResult BagCart()
        {
            int total_item = 0;

            Cart cart = Session["Cart"] as Cart;

            if (cart != null)
                total_item = cart.TotalQuantity();
            ViewBag.TotalItem = total_item;

            return PartialView("BagCart");
        }

    }
}