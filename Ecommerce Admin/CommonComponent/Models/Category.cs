using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommonComponent.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        // [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name should not be longer than 30 characters.")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Enter the description")]
        [StringLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public bool Published { get; set; }

        [Display(Name = "Display Order")]
        [Required(ErrorMessage = "Display Order")]
        public int DisplayOrder { get; set; }
       
    }
}