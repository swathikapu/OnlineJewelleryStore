using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJewelleryStore.Models
{
    public class CartItem
    {
        public Tbl_Product Product { get; set; }
        public int Quantity { get; set; }
    }
}