﻿using FarmHouseDeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.ViewModels
{
    public class RecurringCartItemViewModel
    { 
        public Guid Id { get; set; }
        public DeliveryOption DeliveryOption { get; set; }
        public double SubTotal { get; set; }
        public int Quantity { get; set; } 
        public Product Product { get; set; }
    }
}
