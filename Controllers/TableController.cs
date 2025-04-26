using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using restaurant_management.Data;
using restaurant_management.Models;

namespace restaurant_management.Controllers
{
    public class TableController : Controller
    {
        private readonly RestaurantDbContext _context;

        public TableController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: Table
        public async Task<IActionResult> Index()
        {
            var restaurantDbContext = _context.Tables.Include(t => t.Restaurant);
            return View(await restaurantDbContext.ToListAsync());
        }

        // GET: Table/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Tables
                .Include(t => t.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // GET: Table/Create
        public IActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(_context.Restaurants, "Id", "Name");
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(TableStatus)).Cast<TableStatus>());
            return View();
        }

        // POST: Table/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TableNumber,Capacity,Status,RestaurantId")] Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.RestaurantId = new SelectList(_context.Restaurants, "Id", "Name", table.RestaurantId);
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(TableStatus)).Cast<TableStatus>(), table.Status);
            return View(table);
        }

        // GET: Table/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            ViewBag.RestaurantId = new SelectList(_context.Restaurants, "Id", "Name", table.RestaurantId);
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(TableStatus)).Cast<TableStatus>(), table.Status);
            return View(table);
        }

        // POST: Table/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TableNumber,Capacity,Status,RestaurantId")] Table table)
        {
            if (id != table.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableExists(table.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.RestaurantId = new SelectList(_context.Restaurants, "Id", "Name", table.RestaurantId);
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(TableStatus)).Cast<TableStatus>(), table.Status);
            return View(table);
        }

        // GET: Table/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Tables
                .Include(t => t.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // POST: Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table != null)
            {
                _context.Tables.Remove(table);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableExists(int id)
        {
            return _context.Tables.Any(e => e.Id == id);
        }
    }
}
