using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryStore.Repository;
using OnlineJewelleryStore.Models;

namespace OnlineJewelleryStore.Controllers
{
    public class HomeController : Controller
    {
        MainRepository mainRepo = new MainRepository();
        public ActionResult Index()
        {
            return View(mainRepo);
        }

        public ActionResult AddToCart(int productId, int quantity)
        {
            Tbl_Product product = mainRepo.GetProductById(productId);
            CartItem item = new CartItem() { Product = product, Quantity = quantity };
            Cart cart = mainRepo.GetCartFromSession(Session);
            cart.AddItem(item);
            Session["cart"] = cart;    // update cart with new details.
            return PartialView("_Cartpartial", cart);
        }

        public JsonResult IncrementProduct(int productId)
        {
            Cart cart = mainRepo.GetCartFromSession(Session);
            CartItem item = cart.GetItem(productId);
            cart.AddItem(item);
            var result = new { qty = item.Quantity, price = item.TotalPrice };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _Cartpartial()
        {
            Cart cart = mainRepo.GetCartFromSession(Session);
            return PartialView(cart);
        }
    }
}