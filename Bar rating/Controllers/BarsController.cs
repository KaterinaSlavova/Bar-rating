using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bar_rating.Data;
using Bar_rating.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Bar_rating.Controllers
{
    public class BarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public BarsController(ApplicationDbContext context)
        {
          
            _context = context;
            
        }

        //[Authorize(Roles = "Administrator")]
        // GET: Bars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bar.ToListAsync());
        }

        // GET: Bars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bars = await _context.Bar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bars == null)
            {
                return NotFound();
            }

            return View(bars);
        }

        // GET: Bars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Photo,Description")] Bars bars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bars);
        }

        // GET: Bars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bars = await _context.Bar.FindAsync(id);
            if (bars == null)
            {
                return NotFound();
            }
            return View(bars);
        }

        // POST: Bars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photo,Description")] Bars bars)
        {
            if (id != bars.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarsExists(bars.Id))
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
            return View(bars);
        }

        // GET: Bars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bars = await _context.Bar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bars == null)
            {
                return NotFound();
            }

            return View(bars);
        }

        // POST: Bars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bars = await _context.Bar.FindAsync(id);
            if (bars != null)
            {
                _context.Bar.Remove(bars);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarsExists(int id)
        {
            return _context.Bar.Any(e => e.Id == id);
        }
    }
}
