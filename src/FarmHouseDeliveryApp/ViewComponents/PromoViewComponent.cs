using FarmHouseDeliveryApp.Data;
using FarmHouseDeliveryApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.ViewComponents
{
    public class PromoViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public PromoViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var products = _context.Product.Take(4).ToList();

            return View(products);
        }
    }
}
