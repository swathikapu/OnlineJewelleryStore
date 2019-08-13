using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            TryUpdateModel(member);
            if (ModelState.IsValid)
            {
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
                return RedirectToAction("Index", "Home");
            }
            return View(member);
        }
    }
}