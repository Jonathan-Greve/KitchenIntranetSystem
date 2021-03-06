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
    public class KitchenBankAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenBankAccountsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: KitchenBankAccounts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KitchenBankAccounts.Include(k => k.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KitchenBankAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchenBankAccounts = await _context.KitchenBankAccounts
                .Include(k => k.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (kitchenBankAccounts == null)
            {
                return NotFound();
            }

            return View(kitchenBankAccounts);
        }

        // GET: KitchenBankAccounts/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: KitchenBankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,NameOfBank,IsActive")] KitchenBankAccounts kitchenBankAccounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitchenBankAccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", kitchenBankAccounts.UserId);
            return View(kitchenBankAccounts);
        }

        // GET: KitchenBankAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchenBankAccounts = await _context.KitchenBankAccounts.SingleOrDefaultAsync(m => m.Id == id);
            if (kitchenBankAccounts == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", kitchenBankAccounts.UserId);
            return View(kitchenBankAccounts);
        }

        // POST: KitchenBankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,NameOfBank,IsActive")] KitchenBankAccounts kitchenBankAccounts)
        {
            if (id != kitchenBankAccounts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitchenBankAccounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitchenBankAccountsExists(kitchenBankAccounts.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", kitchenBankAccounts.UserId);
            return View(kitchenBankAccounts);
        }

        // GET: KitchenBankAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchenBankAccounts = await _context.KitchenBankAccounts
                .Include(k => k.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (kitchenBankAccounts == null)
            {
                return NotFound();
            }

            return View(kitchenBankAccounts);
        }

        // POST: KitchenBankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitchenBankAccounts = await _context.KitchenBankAccounts.SingleOrDefaultAsync(m => m.Id == id);
            _context.KitchenBankAccounts.Remove(kitchenBankAccounts);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool KitchenBankAccountsExists(int id)
        {
            return _context.KitchenBankAccounts.Any(e => e.Id == id);
        }
    }
}
