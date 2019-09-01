using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelleryStore.Models
{
    public class ProductViewModel
    {
        private List<SelectListItem> _Quantity = new List<SelectListItem>() {  };
        public Tbl_Product Product { get; set; }
        public List<SelectListItem> Quantity
        {
            get {
                for (int i = 0; i < 10; i++)
                {
                    _Quantity.Add(
                        new SelectListItem
                        {
                            Text = i.ToString(),
                            Value = i.ToString()
                        }
                    );
                }
                return _Quantity;
            }
        }
        public int SelectedQuantity { get; set; }
    }
}

//new SelectListItem
//            {
//                Text = category.Name,
//                Value = Url.Action(
//                    "ProductIndex",
//                    "ProductDashboard",
//                    new { selectedId = category.Id }
//                ),
//                Selected = category.Id == ViewBag.SelectedId
//            }