using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryStore.Models;
using OnlineJewelleryStore.Repository;

namespace OnlineJewelleryStore.Controllers
{
    public class MemberDashboardController : Controller
    {
        MainRepository mainRepo = new MainRepository();
        public ActionResult Index()
        {
            return View(mainRepo.db.Tbl_Member.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Member member)
        {

            TryUpdateModel(member);
            if (ModelState.IsValid)
            {
                mainRepo.db.Tbl_Member.Add(member);
                mainRepo.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Member memberItem = mainRepo.db.Tbl_Member.Find(id);
            if (memberItem == null)
            {
                return HttpNotFound();
            }
            return View(memberItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Member member)
        {
            // We dont want count/ empty image from the edited member, so using the id of the
            // edited member, we are retrieving the record from database and applying
            // all the changes except count/ empty image.
            Tbl_Member memberInDb = mainRepo.db.Tbl_Member.Single(x => x.Id == member.Id);
            // if the user gives a new image file, update the member
            // in database with the given image.
         
            memberInDb.FirstName = member.FirstName;
            memberInDb.LastName = member.LastName;
            memberInDb.Email = member.Email;
            memberInDb.UserName = member.UserName;
            memberInDb.Password = member.Password;
            memberInDb.RoleId = member.RoleId;
            TryUpdateModel(memberInDb);
            if (ModelState.IsValid)
            {
                mainRepo.db.Entry(memberInDb).State = EntityState.Modified;
                mainRepo.db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memberInDb);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Member member = mainRepo.db.Tbl_Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Member member = mainRepo.db.Tbl_Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Member member = mainRepo.db.Tbl_Member.Find(id);
            mainRepo.db.Tbl_Member.Remove(member);
            mainRepo.db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mainRepo.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}