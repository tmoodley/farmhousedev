using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Models
{
    public class DeliveryDate
    {
        public Guid Id { get; set; }
        public DateTime ScheduleDate { get; set; }
    }
}
