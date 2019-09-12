using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineJewelleryStore.Models;
using OnlineJewelleryStore.Repository;

namespace OnlineJewelleryStore.Controllers
{
    public class AccountController : Controller
    {
       
        MainRepository mainRepo = new MainRepository();
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Tbl_Member member)
        {
            member.RoleId = 2;    // user account.
            TryUpdateModel(member);
            if (ModelState.IsValid)
            {
                Session["username"] = member.UserName;
                Session["password"] = member.Password;
                Session["roleId"] = member.RoleId;
                mainRepo.SaveMemberToDB(member);
                return RedirectToAction("Index", "Home");
            }
            return View(member);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Tbl_Member member = mainRepo.GetMember(username, password);
            if (member != null)
            {
                Session["username"] = username;
                Session["password"] = password;
                Session["roleId"] = member.RoleId;
                if(Session["destination"] == null)
                    return RedirectToAction("Index", "Home");
                else
                {
                    DestinationRoute destination = (DestinationRoute)Session["destination"];
                    Session.Remove("destination");
                    return RedirectToAction(destination.ActionName, destination.ControllerName);
                }
            }
            return View(member);
        }

        public ActionResult Logout()
        {
            Session.Remove("username");
            Session.Remove("password");
            Session.Remove("cart");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Member()
        {
            return View();
        }

        public ActionResult MyOrders()
        {
            string username = Session["username"].ToString();
            string password = Session["password"].ToString();
            Tbl_Member member = mainRepo.GetMember(username, password);
            List<Tbl_Order> orders = mainRepo.GetOrders(member.Id);
            return View(orders);
        }
    }
}