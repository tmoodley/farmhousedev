using FarmHouseDeliveryApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmHouseDeliveryApp.Models;

namespace FarmHouseDeliveryApp.Services
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category Add(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category Get(int id)
        {
            return _context.Category.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category;
        }
    }
}
