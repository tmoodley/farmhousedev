using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CCType { get; set; }
        public string CreditCard { get; set; }
        public string ExpDate { get; set; }
        public string SecurityCode { get; set; }
        public string Billing_Address { get; set; }
        public string Billing_City { get; set; }
        public string Billing_Province { get; set; }
        public string Billing_PostalCode { get; set; }
        public string Shipping_Address { get; set; }
        public string Shipping_City { get; set; }
        public string Shipping_Province { get; set; }
        public string Shipping_PostalCode { get; set; }
        public string Phone { get; set; }
    }
}
