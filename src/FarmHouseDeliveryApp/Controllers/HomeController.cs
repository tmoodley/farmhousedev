using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FarmHouseDeliveryApp.Controllers
{
    public class HomeController : Controller
    { 
        public void SaveKey(HttpContext httpContext)
        { 
            const string sessionKey = "cart_id";
            const string dateSeenKey = "dateSeen";
            DateTime dateFirstSeen;
            var value = httpContext.Session.GetString(sessionKey);
            if (string.IsNullOrEmpty(value))
            {
                dateFirstSeen = DateTime.Now;
                var serialisedDate = JsonConvert.SerializeObject(dateFirstSeen);
                httpContext.Session.SetString(dateSeenKey, serialisedDate);
                var cart_id = Guid.NewGuid().ToString();
                httpContext.Session.SetString(sessionKey, cart_id);
            }
        }
        public IActionResult Index()
        {
            SaveKey(HttpContext);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
