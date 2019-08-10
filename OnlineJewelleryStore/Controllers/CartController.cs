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
        public ActionResult Add(int productId, int quantity)
        {
            Tbl_Product product = mainRepo.GetProductById(productId);
            CartItem item = new CartItem() { Product = product, Quantity = quantity };
            Cart cart;
            if (Session["cart"] == null)
                cart = new Cart();
            else
                cart = (Cart)Session["cart"];
            cart.Add(item);
            Session["cart"] = cart;    // update cart with new details.
            return RedirectToAction("Index", "Home");
        }
    }
}