using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Models
{
    public class RecurringCartItem
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int DeliveryOptionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
