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

        public ActionResult Buy()
        {
            Cart cart = mainRepo.GetCartFromSession(Session);
            string username = Session["username"].ToString();
            string password = Session["password"].ToString();
            Tbl_Member member = mainRepo.GetMember(username, password);
            Tbl_Order order = new Tbl_Order()
            {
                CreationDate = DateTime.Now,
                MemberId = member.Id,
                Payment = (decimal)cart.TotalPrice,
                PaymentType = "paypal",
            };
            mainRepo.SaveOrderToDB(order);
            foreach(var item in cart.Items)
            {
                Tbl_Product product = mainRepo.GetProductById(item.Product.Id);
                Tbl_OrderDetails orderDetails = new Tbl_OrderDetails()
                {
                    OrderId = order.Id,
                    ProductId = item.Product.Id,
                    Price = (decimal)item.TotalPrice,
                    Quantity = item.Quantity,
                };
                mainRepo.SaveOrderDetailsToDB(orderDetails);
            }
           
            return View(order);
        }
    }
}