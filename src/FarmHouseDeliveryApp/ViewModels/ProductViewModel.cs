using FarmHouseDeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.ViewModels
{
    public class ProductViewModel
    { 
        public Product Product { get; set; }
        public int DeliveryOptionId { get; set; } 
    }
}
