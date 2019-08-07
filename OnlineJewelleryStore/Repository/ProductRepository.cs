using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineJewelleryStore.Models;

namespace OnlineJewelleryStore.Repository
{
    public class ProductRepository
    {
        JewelleryDBEntities db = new JewelleryDBEntities();
        public List<Tbl_Product> GetProductsByCategoryId(int categoryId)
        {
            return db.Tbl_Product.Where(p => p.CategoryId == categoryId).ToList();

        }
    }
}