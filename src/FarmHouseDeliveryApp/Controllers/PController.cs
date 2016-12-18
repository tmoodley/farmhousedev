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
    public class PController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: P
        public IActionResult Index(string id)
        {
            var product = _context.Product.SingleOrDefaultAsync(x => x.Url == id);
            return View(product);
        }

        // GET: P/Details/5
        public IActionResult Details(string url)
        {
            var product = _context.Product.Single(x => x.Url == url);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: P/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Categories");
            return View();
        }

        // POST: P/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Body,CategoryId,Cost,Description,H1,Image,IsPromo,Keywords,Name,Price,ShortDescription,Thumbnail,Title,UpdateDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Categories", product.CategoryId);
            return View(product);
        }

        // GET: P/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Categories", product.CategoryId);
            return View(product);
        }

        // POST: P/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Body,CategoryId,Cost,Description,H1,Image,IsPromo,Keywords,Name,Price,ShortDescription,Thumbnail,Title,UpdateDate")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Categories", product.CategoryId);
            return View(product);
        }

        // GET: P/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: P/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.Id == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
