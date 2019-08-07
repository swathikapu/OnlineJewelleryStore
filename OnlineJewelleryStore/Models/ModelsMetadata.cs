using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJewelleryStore.Models
{
    [MetadataType(typeof(Tbl_ProductMetaData))]
    public partial class Tbl_Product
    {

    }
    public class Tbl_ProductMetaData
    {
        [DataType(DataType.Currency)]
        public Nullable<decimal> Price { get; set; }
    }
   
}