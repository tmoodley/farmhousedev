using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FarmHouseDeliveryApp.Data;
using FarmHouseDeliveryApp.ViewComponents;
using FarmHouseDeliveryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using FarmHouseDeliveryApp.Helpers;
using FarmHouseDeliveryApp.ViewModels;

namespace FarmHouseDeliveryApp.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Checkout/Details/5
        public ActionResult Index()
        {
            var dept = _context.DeliveryOption;
            var depts = new SelectList(dept, "Id", "Name");
            ViewData["DeliveryOptionId"] = depts;
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            //Add to Recurring Items
            var cartId = UserHelpers.GetKey(HttpContext, this.User);
            var products = _context.ShoppingCartItem.Where(x => x.CartId == cartId).ToList();

            foreach(var product in products)
            {
                AddProuctToRecurring(product, id);
            }

            return RedirectToAction("Create");
        }

        private void AddProuctToRecurring(ShoppingCartItem product, int deliveryOptionId)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var email = currentUser.Identity.Name;

            var userid = UserHelpers.GetUserId(currentUser);


            RecurringCartItem recurringCartItem = new RecurringCartItem();
            recurringCartItem.ProductId = product.ProductId;
            recurringCartItem.Quantity = product.Quantity;
            recurringCartItem.DateAdded = DateTime.Now;
            recurringCartItem.DeliveryOptionId = deliveryOptionId;
            recurringCartItem.CustomerId = new Guid(userid);

            if (ModelState.IsValid)
            {
                recurringCartItem.Id = Guid.NewGuid();
                _context.Add(recurringCartItem);
                _context.SaveChanges();
            }
        }

        // GET: Checkout/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Checkout/Create
        public ActionResult Create()
        {
            var cartId = UserHelpers.GetKey(HttpContext, this.User);
            var products = _context.RecurringCartItem.Where(x => x.CustomerId == cartId).ToList();

            RecurringCartViewModel cvm = new RecurringCartViewModel();
            cvm.CartId = cartId;
            double total = 0.00; ;
            foreach (var product in products)
            {
                Product prod = _context.Product.Where(x => x.Id == product.ProductId).FirstOrDefault();

                RecurringCartItemViewModel civm = new RecurringCartItemViewModel();
                civm.Id = product.Id;
                civm.Product = prod;
                civm.Quantity = product.Quantity;
                civm.SubTotal = product.Quantity * prod.Price;
                civm.DeliveryOption = _context.DeliveryOption.Where(x => x.Id == product.DeliveryOptionId).First();
                total += civm.SubTotal;
                cvm.CartItems = new List<RecurringCartItemViewModel>();
                cvm.CartItems.Add(civm);
            }
            cvm.Total = total;
            return View(cvm);
        }

        // POST: Checkout/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Checkout/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Checkout/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Checkout/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Checkout/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}