using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Models
{
    public class UrlRewrite
    {
        public int Id { get; set; }
        public string PageURL { get; set; }
        public string PageSEOUrl { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string PageContent { get; set; } 
    }
}
