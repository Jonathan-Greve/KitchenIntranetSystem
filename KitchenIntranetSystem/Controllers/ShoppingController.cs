using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitchenIntranetSystem.Data;
using KitchenIntranetSystem.Models;
using KitchenIntranetSystem.Interfaces;
using Newtonsoft.Json;

namespace KitchenIntranetSystem.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUser _user;

        public ShoppingController(ApplicationDbContext context, IUser user)
        {
            _context = context;
            _user = user;
        }

        // GET: Shopping
        public async Task<IActionResult> Index()
        {
            var chartData = _context.Shopping
                            .Where(d => DateTime.Now > d.Date && d.Date > DateTime.Now.AddYears(-1))
                            .Select(c => new { c.Price, c.Date, c.User })
                            .OrderByDescending(c => c.Date)
                            .AsEnumerable()
                            .Select(c => new Tuple<decimal, string, string, string>(c.Price, c.Date.ToString("MMMM"), _user.GetFullName(c.User.Id), c.Date.ToString("dd")))
                            .OrderBy(c => c.Item4)
                            .ToArray();
            ViewData["UserNames"] = JsonConvert.SerializeObject(_user.GetAllUsersFullName);
            ViewData["ChartData"] = JsonConvert.SerializeObject(chartData);
            var applicationDbContext = _context.Shopping.Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Shopping/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shopping
                .Include(s => s.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shopping == null)
            {
                return NotFound();
            }

            return View(shopping);
        }

        // GET: Shopping/Create
        public IActionResult Create()
        {
            ViewData["UserFullName"] = _user.GetFullName(User);
            return View();
        }

        // POST: Shopping/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ItemBought,Price,Date")] Shopping shopping)
        {
            if (ModelState.IsValid)
            {
                shopping.UserId = _user.GetId(User);
                _context.Add(shopping);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", shopping.UserId);
            return View(shopping);
        }

        // GET: Shopping/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shopping.SingleOrDefaultAsync(m => m.Id == id);
            if (shopping == null)
            {
                return NotFound();
            }
            ViewData["UserFullName"] = _user.GetFullName(User);
            return View(shopping);
        }

        // POST: Shopping/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ItemBought,Price,Date")] Shopping shopping)
        {
            if (id != shopping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingExists(shopping.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", shopping.UserId);
            return View(shopping);
        }

        // GET: Shopping/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shopping
                .Include(s => s.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shopping == null)
            {
                return NotFound();
            }

            return View(shopping);
        }

        // POST: Shopping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopping = await _context.Shopping.SingleOrDefaultAsync(m => m.Id == id);
            _context.Shopping.Remove(shopping);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ShoppingExists(int id)
        {
            return _context.Shopping.Any(e => e.Id == id);
        }
    }
}
