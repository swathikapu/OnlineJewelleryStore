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

        public ActionResult Products(int categoryId)
        {
            List<Tbl_Product> products = mainRepo.GetProductsByCategoryId(categoryId);
            return View(products);
        }

       
    }
}