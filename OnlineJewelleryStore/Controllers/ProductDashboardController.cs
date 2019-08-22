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
    public class ProductDashboardController : Controller
    {
        MainRepository mainRepo = new MainRepository();
        public ActionResult ProductIndex(int selectedId)
        {
            ViewBag.SelectedId = selectedId;
            return View(mainRepo);
        }
        public ActionResult Create(int selectedId)
        {
            ViewBag.SelectedId = selectedId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Product product)
        {

            TryUpdateModel(product);
            if (ModelState.IsValid)
            {
                string categoryName = mainRepo.GetCategoryName(product.CategoryId);
                string imagePath = "~/Content/Images/" + categoryName + "/" + product.ImageFile.FileName;
                product.Image = imagePath;
                product.ImageFile.SaveAs(Server.MapPath(imagePath));
                mainRepo.db.Tbl_Product.Add(product);
                mainRepo.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product productItem  = mainRepo.db.Tbl_Product.Find(id);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(productItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Product product)
        {
            // We dont want count/ empty image from the edited product, so using the id of the
            // edited product, we are retrieving the record from database and applying
            // all the changes except count/ empty image.
            Tbl_Product productInDb = mainRepo.db.Tbl_Product.Single(x => x.Id == product.Id);
            // if the user gives a new image file, update the product
            // in database with the given image.
            try
            {
                productInDb.ImageFile = product.ImageFile;
                string categoryName = mainRepo.GetCategoryName(product.CategoryId);
                string imagePath = "~/Content/Images/" + categoryName + "/" + product.ImageFile.FileName;
                productInDb.Image = imagePath;
                productInDb.ImageFile.SaveAs(Server.MapPath(imagePath));
            }
            catch (NullReferenceException)
            {
                // No new image file choosen by the user.
            }
            productInDb.Name = product.Name;
            productInDb.IsActive = product.IsActive;
            productInDb.CreatedDate = product.CreatedDate;
            productInDb.Description = product.Description;
            productInDb.IsFeatured = product.IsFeatured;
            productInDb.Quantity = product.Quantity;
            productInDb.Price = product.Price;
            TryUpdateModel(productInDb);
            if (ModelState.IsValid)
            {
                mainRepo.db.Entry(productInDb).State = EntityState.Modified;
                mainRepo.db.SaveChanges();
                return RedirectToAction("ProductIndex", new { selectedId = product.CategoryId });
            }
            return View(productInDb);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product product = mainRepo.db.Tbl_Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product product = mainRepo.db.Tbl_Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Product product = mainRepo.db.Tbl_Product.Find(id);
            mainRepo.db.Tbl_Product.Remove(product);
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