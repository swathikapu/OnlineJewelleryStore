using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryStore.Models;

namespace OnlineJewelleryStore.Controllers
{
    public class CheckoutController : Controller
    {
        public ActionResult Checkout()
        {
            Cart cart;
            if (Session["cart"] == null)
                cart = new Cart();
            else
                cart = (Cart)Session["cart"];
            return View(cart);
        }
    }
}