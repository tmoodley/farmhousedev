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
    public class DeliveryOptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryOptionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: DeliveryOptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeliveryOption.ToListAsync());
        }

        // GET: DeliveryOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryOption = await _context.DeliveryOption.SingleOrDefaultAsync(m => m.Id == id);
            if (deliveryOption == null)
            {
                return NotFound();
            }

            return View(deliveryOption);
        }

        // GET: DeliveryOptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeliveryOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Recurring")] DeliveryOption deliveryOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryOption);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(deliveryOption);
        }

        // GET: DeliveryOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryOption = await _context.DeliveryOption.SingleOrDefaultAsync(m => m.Id == id);
            if (deliveryOption == null)
            {
                return NotFound();
            }
            return View(deliveryOption);
        }

        // POST: DeliveryOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Recurring")] DeliveryOption deliveryOption)
        {
            if (id != deliveryOption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryOptionExists(deliveryOption.Id))
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
            return View(deliveryOption);
        }

        // GET: DeliveryOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryOption = await _context.DeliveryOption.SingleOrDefaultAsync(m => m.Id == id);
            if (deliveryOption == null)
            {
                return NotFound();
            }

            return View(deliveryOption);
        }

        // POST: DeliveryOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryOption = await _context.DeliveryOption.SingleOrDefaultAsync(m => m.Id == id);
            _context.DeliveryOption.Remove(deliveryOption);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DeliveryOptionExists(int id)
        {
            return _context.DeliveryOption.Any(e => e.Id == id);
        }
    }
}
