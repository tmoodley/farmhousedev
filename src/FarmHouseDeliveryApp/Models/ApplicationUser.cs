using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FarmHouseDeliveryApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
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
