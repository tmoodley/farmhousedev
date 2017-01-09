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
    public class RecurringCartItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecurringCartItemsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: RecurringCartItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecurringCartItem.ToListAsync());
        }

        // GET: RecurringCartItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurringCartItem = await _context.RecurringCartItem.SingleOrDefaultAsync(m => m.Id == id);
            if (recurringCartItem == null)
            {
                return NotFound();
            }

            return View(recurringCartItem);
        } 

        // GET: RecurringCartItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecurringCartItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,DateAdded,DeliveryOptionId,ProductId,Quantity,UpdateDate")] RecurringCartItem recurringCartItem)
        {
            if (ModelState.IsValid)
            {
                recurringCartItem.Id = Guid.NewGuid();
                _context.Add(recurringCartItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(recurringCartItem);
        }

        // GET: RecurringCartItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurringCartItem = await _context.RecurringCartItem.SingleOrDefaultAsync(m => m.Id == id);
            if (recurringCartItem == null)
            {
                return NotFound();
            }
            return View(recurringCartItem);
        }

        // POST: RecurringCartItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CustomerId,DateAdded,DeliveryOptionId,ProductId,Quantity,UpdateDate")] RecurringCartItem recurringCartItem)
        {
            if (id != recurringCartItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recurringCartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecurringCartItemExists(recurringCartItem.Id))
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
            return View(recurringCartItem);
        }
         
        // POST: RecurringCartItems/Delete/5
        [HttpPost, ActionName("Delete")] 
        public async Task<IActionResult> Delete(Guid id)
        {
            var recurringCartItem = await _context.RecurringCartItem.SingleOrDefaultAsync(m => m.Id == id);
            _context.RecurringCartItem.Remove(recurringCartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create","Checkout");
        }

        private bool RecurringCartItemExists(Guid id)
        {
            return _context.RecurringCartItem.Any(e => e.Id == id);
        }
    }
}
