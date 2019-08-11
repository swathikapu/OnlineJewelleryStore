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
            return PartialView("_Productpartial", product);
        }

        public ActionResult Products(int categoryId)
        {
            List<Tbl_Product> products = mainRepo.GetProductsByCategoryId(categoryId);
            return View(products);
        }

        public ActionResult _Productpartial(int ?id)
        {
            Tbl_Product product = mainRepo.GetProductById((int)id);
            return PartialView(product);
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}