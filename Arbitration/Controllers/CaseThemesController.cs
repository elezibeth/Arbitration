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
    public class CaseThemesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaseThemesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CaseThemes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CaseThemes.Include(c => c.CaseTheory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CaseThemes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseTheme = await _context.CaseThemes
                .Include(c => c.CaseTheory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseTheme == null)
            {
                return NotFound();
            }

            return View(caseTheme);
        }

        // GET: CaseThemes/Create
        public IActionResult CreateCaseTheme()
        {
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id");
            ViewBag["name"] = _context.ConsumerClaimants.Where(x => x.FirstName == "Liz");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCaseTheme([Bind("Id,CaseTheoryId,ArbiterChair,CoreTruth")] CaseTheme caseTheme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caseTheme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", caseTheme.CaseTheoryId);
            return View(caseTheme);
        }

        // GET: CaseThemes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseTheme = await _context.CaseThemes.FindAsync(id);
            if (caseTheme == null)
            {
                return NotFound();
            }
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", caseTheme.CaseTheoryId);
            return View(caseTheme);
        }

        // POST: CaseThemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CaseTheoryId,ArbiterChair,CoreTruth")] CaseTheme caseTheme)
        {
            if (id != caseTheme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseTheme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseThemeExists(caseTheme.Id))
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
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", caseTheme.CaseTheoryId);
            return View(caseTheme);
        }

        // GET: CaseThemes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseTheme = await _context.CaseThemes
                .Include(c => c.CaseTheory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseTheme == null)
            {
                return NotFound();
            }

            return View(caseTheme);
        }

        // POST: CaseThemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caseTheme = await _context.CaseThemes.FindAsync(id);
            _context.CaseThemes.Remove(caseTheme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseThemeExists(int id)
        {
            return _context.CaseThemes.Any(e => e.Id == id);
        }
    }
}
