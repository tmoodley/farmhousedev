using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmHouseDeliveryApp.Data;
using FarmHouseDeliveryApp.Models;
using FarmHouseDeliveryApp.ViewComponents;
using FarmHouseDeliveryApp.ViewModels;
using FarmHouseDeliveryApp.Helpers;

namespace FarmHouseDeliveryApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Cart
        public IActionResult Index()
        {
            var cartId = UserHelpers.GetKey(HttpContext, this.User);
            var products = _context.ShoppingCartItem.Where(x => x.CartId == cartId).ToList();

            CartViewModel cvm = new CartViewModel();
            cvm.CartId = cartId;
            double total = 0.00; ;
            foreach (var product in products)
            {
                Product prod = _context.Product.Where(x => x.Id == product.ProductId).FirstOrDefault();
         
                CartItemViewModel civm = new CartItemViewModel();
                civm.Id = product.Id;
                civm.Product = prod;
                civm.Quantity = product.Quantity;
                civm.SubTotal = product.Quantity * prod.Price;
                total += civm.SubTotal;
                cvm.CartItems = new List<CartItemViewModel>();
                cvm.CartItems.Add(civm);
            }
            cvm.Total = total;
            return View(cvm);
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCartItem = await _context.ShoppingCartItem.SingleOrDefaultAsync(m => m.Id == id);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            return View(shoppingCartItem);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        public async Task<IActionResult> Add([Bind("Id,ProductId,Quantity,DeliveryOptionsId")] ShoppingCartItem shoppingCartItem)
        {
            if (ModelState.IsValid)
            {
                shoppingCartItem.DateCreated = DateTime.Now;
                shoppingCartItem.CartId = UserHelpers.GetKey(HttpContext, this.User);
                var cartItem = await _context.ShoppingCartItem.Where(m => m.CartId == shoppingCartItem.CartId).Where(y => y.ProductId == shoppingCartItem.ProductId).ToListAsync();
                
                if (cartItem.Count <= 0)
                {
                    _context.Add(shoppingCartItem);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Update(shoppingCartItem);
                    await _context.SaveChangesAsync();
                } 

                return RedirectToAction("Index");
            }
            return View(shoppingCartItem);
        }
 

        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        public async Task<IActionResult> Update(Guid id, [Bind("Id,CartId,ProductId,Quantity")] ShoppingCartItem shoppingCartItem)
        {
            if (id != shoppingCartItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingCartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCartItemExists(shoppingCartItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(shoppingCartItem);
        }

    

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")] 
        public async Task<IActionResult> Delete(Guid id)
        {
            var shoppingCartItem = await _context.ShoppingCartItem.SingleOrDefaultAsync(m => m.Id == id);
            _context.ShoppingCartItem.Remove(shoppingCartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ShoppingCartItemExists(Guid id)
        {
            return _context.ShoppingCartItem.Any(e => e.Id == id);
        }
    }
}
