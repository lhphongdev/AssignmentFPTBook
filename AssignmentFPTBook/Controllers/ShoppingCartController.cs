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
            if (Session["Username"] != null)
            {
                var pro = _db.Books.SingleOrDefault(s => s.BookID == id);
                if (pro != null)
                {
                    GetCart().Add(pro);
                }
                return RedirectToAction("ShowToCart", "ShoppingCart");
            }

            return View("ErrorCart");
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
            if (Session["Username"] != null)
            {
                if (Session["Cart"] == null)
                {
                    Response.Write("<script>alert('Cart is empty');window.location='/'</script>");
                }
                Cart cart = Session["Cart"] as Cart;
                return View(cart);
            }
            return View("ErrorCart");
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


        public ActionResult CheckoutSuccess()
        {
            return View();
        }

        public ActionResult Checkout(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order _order = new Order();
                _order.OrderDate = DateTime.Now;
                _order.Username = form["cUsername"];
                _order.Address = form["cAddress"];
                _order.Phone = form["cPhone"];
                _order.TotalPrice = Convert.ToInt32(form["cTotalPrice"]);
                _db.Orders.Add(_order);

                foreach (var item in cart.Items)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderID = _order.OrderID;
                    orderDetail.BookID = item._shopping_product.BookID;
                    orderDetail.Quantity = item._shopping_quantity;
                    orderDetail.AmountPrice = item._shopping_product.Price * item._shopping_quantity;
                    _db.OrderDetails.Add(orderDetail);
                }
                _db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckoutSuccess", "ShoppingCart");
            }
            catch
            {
                return Content("Error checkout, Check information again");
            }
        }


    }
}