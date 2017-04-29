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
    public class BeersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Beers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Beers.Include(b => b.BeerCategories).Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Beers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beers = await _context.Beers
                .Include(b => b.BeerCategories)
                .Include(b => b.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (beers == null)
            {
                return NotFound();
            }

            return View(beers);
        }

        // GET: Beers/Create
        public IActionResult Create()
        {
            ViewData["BeerCategoriesId"] = new SelectList(_context.BeerCategories, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Beers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,BeerCategoriesId,AmountDrunk,Date")] Beers beers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beers);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BeerCategoriesId"] = new SelectList(_context.BeerCategories, "Id", "Id", beers.BeerCategoriesId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", beers.UserId);
            return View(beers);
        }

        // GET: Beers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beers = await _context.Beers.SingleOrDefaultAsync(m => m.Id == id);
            if (beers == null)
            {
                return NotFound();
            }
            ViewData["BeerCategoriesId"] = new SelectList(_context.BeerCategories, "Id", "Id", beers.BeerCategoriesId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", beers.UserId);
            return View(beers);
        }

        // POST: Beers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,BeerCategoriesId,AmountDrunk,Date")] Beers beers)
        {
            if (id != beers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeersExists(beers.Id))
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
            ViewData["BeerCategoriesId"] = new SelectList(_context.BeerCategories, "Id", "Id", beers.BeerCategoriesId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", beers.UserId);
            return View(beers);
        }

        // GET: Beers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beers = await _context.Beers
                .Include(b => b.BeerCategories)
                .Include(b => b.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (beers == null)
            {
                return NotFound();
            }

            return View(beers);
        }

        // POST: Beers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beers = await _context.Beers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Beers.Remove(beers);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BeersExists(int id)
        {
            return _context.Beers.Any(e => e.Id == id);
        }
    }
}
