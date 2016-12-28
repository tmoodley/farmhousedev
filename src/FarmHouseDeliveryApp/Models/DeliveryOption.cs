using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Models
{
    public class DeliveryOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Recurring { get; set; }
    }
}
