using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Models
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
