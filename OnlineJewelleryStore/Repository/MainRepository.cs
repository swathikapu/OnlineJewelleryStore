using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineJewelleryStore.Models;

namespace OnlineJewelleryStore.Repository
{
    public class MainRepository
    {
        public JewelleryDBEntities db = new JewelleryDBEntities();
        public List<Tbl_Category> GetAllCategories()
        {
            return db.Tbl_Category.ToList();
        }

        public List<Tbl_Product> GetProductsByCategoryId(int categoryId)
        {
            return db.Tbl_Product.Where(p => p.CategoryId == categoryId).ToList();

        }

        public List<Tbl_Product> GetFeaturedProductsByCategoryId(int categoryId)
        {
            return db.Tbl_Product.Where(p => p.CategoryId == categoryId && p.IsFeatured == true).ToList();
        }

        public Tbl_Product GetProductById(int productId)
        {
            return db.Tbl_Product.Find(productId);
        }

        public Tbl_Category GetCategory(int categoryId)
        {
            return db.Tbl_Category.Find(categoryId);
        }

        public string GetCategoryName(int categoryId)
        {
            Tbl_Category category= db.Tbl_Category.Find(categoryId);
            return category.Name.Replace(" ", "");
        }

        public void SaveMemberToDB(Tbl_Member member)
        {
            db.Tbl_Member.Add(member);
            db.SaveChanges();
        }

        public void SaveOrderToDB(Tbl_Order order)
        {
            db.Tbl_Order.Add(order);
            db.SaveChanges();
        }

        public void SaveOrderDetailsToDB(Tbl_OrderDetails orderDetails)
        {
            db.Tbl_OrderDetails.Add(orderDetails);
            db.SaveChanges();
        }

        public bool IsValidMember(string username, string password)
        {
          Tbl_Member member = db.Tbl_Member.Single(m => m.UserName == username && m.Password == password);
            if (member == null)
                return false;
            else
                return true;
        }

        public Tbl_Member GetMember(string username, string password)
        {
            try
            {
                 return (Tbl_Member)db.Tbl_Member.Single(m => m.UserName == username && m.Password == password);
            }

            catch
            {
                return null;
            }            
        }

        public Cart GetCartFromSession(HttpSessionStateBase session)
        {
            Cart cart;
            if (session["cart"] == null)
                cart = new Cart();
            else
                cart = (Cart)session["cart"];
            return cart;
        }

        public List<Tbl_Order> GetOrders(int memberId)
        {
            return db.Tbl_Order.Where(o => o.MemberId == memberId).ToList();
        }
    }
}