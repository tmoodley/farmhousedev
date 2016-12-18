using FarmHouseDeliveryApp.Data;
using FarmHouseDeliveryApp.ViewModels;
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
            List<DepartmentViewModel> deptViewModel = new List<DepartmentViewModel>();
            var depts = _context.Department.ToList();
            foreach (var dept in depts)
            {
                DepartmentViewModel dvm = new DepartmentViewModel();
                dvm.Name = dept.Name;
                dvm.Description = dept.Description;
                dvm.Url = dept.Url;
                dvm.Categories = _context.Category.Where(x => x.DepartmentId == dept.Id).ToList();

                deptViewModel.Add(dvm);
                
            }
            return View(deptViewModel);
        }
    }
}
