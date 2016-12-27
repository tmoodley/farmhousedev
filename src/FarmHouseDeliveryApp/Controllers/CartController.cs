using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmHouseDeliveryApp.Data;
using FarmHouseDeliveryApp.Models;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShoppingCartItem.ToListAsync());
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Quantity")] ShoppingCartItem shoppingCartItem)
        {
            if (ModelState.IsValid)
            {
                shoppingCartItem.Id = Guid.NewGuid();
                _context.Add(shoppingCartItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shoppingCartItem);
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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

        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProductId,Quantity")] ShoppingCartItem shoppingCartItem)
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

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
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
