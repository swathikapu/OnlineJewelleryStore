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
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            if (Session["cart"] == null)
                cart = new List<CartItem>();
            cart.Add(item);
            Session["cart"] = cart;
            return RedirectToAction("Index", "Home");
        }
    }
}