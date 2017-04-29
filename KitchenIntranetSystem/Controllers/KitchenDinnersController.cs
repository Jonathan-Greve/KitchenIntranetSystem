using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitchenIntranetSystem.Data;
using KitchenIntranetSystem.Models;

namespace KitchenIntranetSystem.Controllers
{
    public class KitchenDinnersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenDinnersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: KitchenDinners
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KitchenDinners.Include(k => k.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KitchenDinners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchenDinners = await _context.KitchenDinners
                .Include(k => k.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (kitchenDinners == null)
            {
                return NotFound();
            }

            return View(kitchenDinners);
        }

        // GET: KitchenDinners/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: KitchenDinners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Menu,Price,SignUpCloseDate,Date")] KitchenDinners kitchenDinners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitchenDinners);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", kitchenDinners.UserId);
            return View(kitchenDinners);
        }

        // GET: KitchenDinners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchenDinners = await _context.KitchenDinners.SingleOrDefaultAsync(m => m.Id == id);
            if (kitchenDinners == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", kitchenDinners.UserId);
            return View(kitchenDinners);
        }

        // POST: KitchenDinners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Menu,Price,SignUpCloseDate,Date")] KitchenDinners kitchenDinners)
        {
            if (id != kitchenDinners.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitchenDinners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitchenDinnersExists(kitchenDinners.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", kitchenDinners.UserId);
            return View(kitchenDinners);
        }

        // GET: KitchenDinners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchenDinners = await _context.KitchenDinners
                .Include(k => k.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (kitchenDinners == null)
            {
                return NotFound();
            }

            return View(kitchenDinners);
        }

        // POST: KitchenDinners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitchenDinners = await _context.KitchenDinners.SingleOrDefaultAsync(m => m.Id == id);
            _context.KitchenDinners.Remove(kitchenDinners);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool KitchenDinnersExists(int id)
        {
            return _context.KitchenDinners.Any(e => e.Id == id);
        }
    }
}
