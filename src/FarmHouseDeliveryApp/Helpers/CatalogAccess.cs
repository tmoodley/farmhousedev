using FarmHouseDeliveryApp.Data;
using FarmHouseDeliveryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Helpers
{
    public class CatalogAccess
    {
        private readonly ApplicationDbContext _context;

        public CatalogAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve the list of departments
        public List<Department> GetDepartments()
        {
           return _context.Department.ToList();
        }
        // get department details
        public Department GetDepartmentDetails(int department_id)
        {
            return _context.Department.Single(m => m.Id == department_id);
        }

        // Get category details
        public Category GetCategoryDetails(int category_id)
        {
            return _context.Category.Single(x => x.Id == category_id);
        }

        // Get product details
        public Product GetProductDetails(int product_id)
        {
            return _context.Product.Single(x => x.Id == product_id);
        }
        // retrieve the list of categories in a department
        public List<Category> GetCategoriesInDepartment(int department_id)
        {
            return _context.Category.Where(x => x.DepartmentId == department_id).ToList();
        }

        // Retrieve the list of products on catalog promotion
        public List<Product> GetProductsOnFrontPromo(string pageNumber, out int howManyPages)
        {
            howManyPages = _context.Product.Where(x => x.IsPromo == true).Count();
            return _context.Product.Where(x => x.IsPromo == true).ToList();
        }

        // retrieve the list of products featured for a department
        public List<Product> GetProductsOnDeptPromo(int department_id, string pageNumber, out int howManyPages)
        {
            howManyPages = _context.Product.Where(x => x.Categories.DepartmentId == department_id).Count();
            return _context.Product.Where(x => x.Categories.DepartmentId == department_id).ToList();
        }
        // retrieve the list of products in a category
        public List<Product> GetProductsInCategory(int category_id, string pageNumber, out int howManyPages)
        {
            howManyPages = _context.Product.Where(x => x.CategoryId == category_id).Count();
            return _context.Product.Where(x => x.CategoryId == category_id).ToList();
        }
    }

}
