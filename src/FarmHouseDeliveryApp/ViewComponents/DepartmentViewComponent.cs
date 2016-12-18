using FarmHouseDeliveryApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.ViewComponents
{
    public class DepartmentViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public DepartmentViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Department.ToList());
        }
    }
}
