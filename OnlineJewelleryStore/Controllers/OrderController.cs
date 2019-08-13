using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryStore.Models;
using OnlineJewelleryStore.Repository;

namespace OnlineJewelleryStore.Controllers
{
    public class OrderController : Controller
    {
        MainRepository mainRepo = new MainRepository();

        public ActionResult Order()
        {
            Cart cart = mainRepo.GetCartFromSession(Session);
            return View(cart);
        }
    }
}