using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string H1 { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public string Body { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public bool IsPromo { get; set; }
        public string Url { get; set; }

        public int CategoryId { get; set; } 
        public Category Categories { get; set; }
        public DateTime UpdateDate { get; set; } 
    }
}
