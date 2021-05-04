using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Arbitration.Data;
using Arbitration.Models;

namespace Arbitration.Controllers
{
    public class FactualTheoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FactualTheoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FactualTheories
        public async Task<IActionResult> FactualTheory()
        {
            var applicationDbContext = _context.FactualTheories.Include(f => f.CaseTheory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FactualTheories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factualTheory = await _context.FactualTheories
                .Include(f => f.CaseTheory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factualTheory == null)
            {
                return NotFound();
            }

            return View(factualTheory);
        }

        // GET: FactualTheories/Create
        public IActionResult CreateFactualTheory()
        {
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id");
            return View();
        }

        // POST: FactualTheories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFactualTheory([Bind("Id,CaseTheoryId,Name,Description,IsPrimary")] FactualTheory factualTheory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factualTheory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", factualTheory.CaseTheoryId);
            return View(factualTheory);
        }

        // GET: FactualTheories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factualTheory = await _context.FactualTheories.FindAsync(id);
            if (factualTheory == null)
            {
                return NotFound();
            }
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", factualTheory.CaseTheoryId);
            return View(factualTheory);
        }

        // POST: FactualTheories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CaseTheoryId,Name,Description,IsPrimary")] FactualTheory factualTheory)
        {
            if (id != factualTheory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factualTheory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactualTheoryExists(factualTheory.Id))
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
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", factualTheory.CaseTheoryId);
            return View(factualTheory);
        }

        // GET: FactualTheories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factualTheory = await _context.FactualTheories
                .Include(f => f.CaseTheory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factualTheory == null)
            {
                return NotFound();
            }

            return View(factualTheory);
        }

        // POST: FactualTheories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factualTheory = await _context.FactualTheories.FindAsync(id);
            _context.FactualTheories.Remove(factualTheory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactualTheoryExists(int id)
        {
            return _context.FactualTheories.Any(e => e.Id == id);
        }
    }
}
