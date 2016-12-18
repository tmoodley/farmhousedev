using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string H1 { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Image { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }

        public int DepartmentId { get; set; } 
        public Department Departments { get; set; }
        public DateTime UpdateDate { get; set; } 
    }
}
