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
            if(Session["username"] == null &&  Session["password"] == null)
            {
                // This is needed because when the user is not logged in before
                // checking out, show the login page and once logged in show the
                // checkout page.
                DestinationRoute destination = new DestinationRoute()
                {
                    ActionName = "Checkout",
                    ControllerName = "Cart"
                };
                Session["destination"] = destination;
                return RedirectToAction(
                    "Login", 
                    "Account"
                );
            }
            Cart cart =  mainRepo.GetCartFromSession(Session);
            return View(cart);
        }

        public ActionResult Buy()
        {
            return View();
        }
    }
}