using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryStore.Models;
using OnlineJewelleryStore.Repository;

namespace OnlineJewelleryStore.Controllers
{
    public class CartController : Controller
    {
        MainRepository mainRepo = new MainRepository();
        public ActionResult Checkout()
        {
            Cart cart =  mainRepo.GetCartFromSession(Session);
            return View(cart);
        }

        public ActionResult _Checkoutpartial(int productId)
        {
            Cart cart = mainRepo.GetCartFromSession(Session);
            CartItem cartItem = cart.GetItem(productId);
            return PartialView(cartItem);
        }
        
        public ActionResult RemoveFromCart(int productId)
        {
            Cart cart = mainRepo.GetCartFromSession(Session);
            cart.RemoveItem(productId);
            Session["cart"] = cart;
            return RedirectToAction("Checkout");
        }
    }
}