using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommonComponent.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        /*  [Required]
          [Display(Name = "Product Type")]
          public string ProductType { get; set; }

          public IEnumerable<SelectListItem> ProductTypes { get; set; }*/

        [Display(Name = "Visible Individually")]
        public int VisibleIndividually { get; set; }


        //[StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        [Display(Name = "Enter Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }

        [Display(Name = "Published")]
        public bool PublishedProduct { get; set; }

        [Display(Name = "Show on home page")]
        public bool ShowHome { get; set; }

        [Display(Name = "Is Gift Card")]
        public bool GiftCard { get; set; }

        [Display(Name = "Downnloadable Product")]
        public bool Downloadable { get; set; }

        [Display(Name = "Recurring Product")]
        public bool RecurringProduct { get; set; }


        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Display(Name = "Enter Price")]
        public decimal ProductPrize { get; set; }

        [Display(Name = "Discounts")]
        public decimal Discount { get; set; }

        [Display(Name = "Telecommunications, Broadcasting and electronic Services ")]
        public bool Broadcast { get; set; }

        [Display(Name = "Inventary Method")]
        public string InventaryMethod { get; set; }

        [Display(Name = "Allowed Quantities")]
        public int Quantity { get; set; }

        [Display(Name = "Not Returnable")]
        public bool NotReturnable { get; set; }

        [Display(Name = "Shipping enable")]
        public bool Shipping { get; set; }

        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Display(Name = "Length")]
        public int Length { get; set; }

        [Display(Name = "height")]
        public int Height { get; set; }

        [Display(Name = "Width")]
        public int Width { get; set; }

        [Display(Name = "Free Shipping")]
        public bool FreeShipping { get; set; }

        [Display(Name = "Shipping charges")]
        public int ShippingCharge { get; set; }

        [Display(Name = "Categories")]
        public string Category { get; set; }

        [Display(Name = "Manufacturers")]
        public string Manufacturers { get; set; }

        [Display(Name = "Limited to stores")]
        public string LimitedStore { get; set; }

        [Display(Name = "Customer Roles")]
        public string CustomerRole { get; set; }

        [Display(Name = "Require other Product")]
        public bool RequireOtherProduct { get; set; }



        [Display(Name = "Enter Product Image")]
        public byte ProductImage { get; set; }
    }
}