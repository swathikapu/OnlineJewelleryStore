﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryStore.Models;

namespace OnlineJewelleryStore.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Checkout()
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            return View(cart);
        }
    }
}