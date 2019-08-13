﻿using System;
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

    [MetadataType(typeof(Tbl_MemberMetaData))]
    public partial class Tbl_Member
    {
       
    }
    public class Tbl_MemberMetaData
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [RegularExpression(@"^(([A-Za-z]+))$", ErrorMessage = "Please enter alphabets only")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [RegularExpression(@"^(([A-Za-z]+))$", ErrorMessage = "Please enter alphabets only")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your User name")]
        [RegularExpression(@"^(([A-Za-z]+))$", ErrorMessage = "Please enter alphabets only")]
        public string UserName { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Please enter alphabets only")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}