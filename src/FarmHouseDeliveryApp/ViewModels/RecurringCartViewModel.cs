using FarmHouseDeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.ViewModels
{
    public class RecurringCartViewModel
    { 
        public Guid Id { get; set; }
        public double Total { get; set; }
        public Guid CartId { get; set; }
        public List<RecurringCartItemViewModel> CartItems { get; set; }
    }
}
