﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryStore.Models;
using OnlineJewelleryStore.Repository;

namespace OnlineJewelleryStore.Controllers
{
    public class ProductController : Controller
    {
        MainRepository mainRepo = new MainRepository();
        public ActionResult Products(int categoryId)
        {
            List<Tbl_Product> products = mainRepo.GetProductsByCategoryId(categoryId);
            Tbl_Category category = mainRepo.GetCategory(categoryId);
            ViewBag.categoryName = category.Name;
            return View(products);
        }

        public ActionResult _Productpartial(int? id)
        {
            Tbl_Product product = mainRepo.GetProductById((int)id);
            return PartialView(product);
        }

        public ActionResult ProductDetails(int? id)
        {
            Tbl_Product product = mainRepo.GetProductById((int)id);
            return View(product);
        }

        public ActionResult ProductDetails2(int? id)
        {
            ProductViewModel productVM = new ProductViewModel() { Product = mainRepo.GetProductById((int)id) };
            //Tbl_Product product = mainRepo.GetProductById((int)id);
            return View(productVM);
        }

        [HttpPost]
        public ActionResult ProductDetails2(ProductViewModel pvm)
        {
            int selected = pvm.SelectedQuantity;
            return View();
        }
    }
}