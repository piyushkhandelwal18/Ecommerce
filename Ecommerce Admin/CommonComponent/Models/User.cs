using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommonComponent.Models
{
    public class User
    {
       
        public int UserId { get; set; }

        /* [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]*/
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Id")]
        public string UserEmailId { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Enter Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        [Display(Name = "First Name")]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        [Display(Name = "Last Name")]
        public string UserLastName { get; set; }

        /* [Required]
         [Display(Name = "Date Of Birth")]
         //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
         public DateTime Dob { get; set; }

         [Display(Name = "Crated Date")]
         public DateTime CreatedDate { get; set; }*/

        //[Range(3, 10)]
        //[DataType(DataType.)]
        [Required(ErrorMessage = "Address is required")]
       // [StringLength(10, MinimumLength = 3, ErrorMessage = "Telephone should not be longer than 10 characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

       // [Range(3, 10)]
        [Required(ErrorMessage = "Enter Postal code")]
        [Display(Name = "Postal Code")]
        //[DataType(DataType.Currency)]
        public string ZipPostalCode { get; set; }
    }
}