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
    public class CaseTheoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaseTheoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CaseTheories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CaseTheories.Include(c => c.ConsumerClaimant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CaseTheories/Details/5
        public async Task<IActionResult> CaseTheoryDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseTheory = await _context.CaseTheories
                .Include(c => c.ConsumerClaimant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseTheory == null)
            {
                return NotFound();
            }

            return View(caseTheory);
        }

        // GET: CaseTheories/Create

        // GET: CaseTheories/Edit/5




        // GET: CaseTheories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseTheory = await _context.CaseTheories
                .Include(c => c.ConsumerClaimant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseTheory == null)
            {
                return NotFound();
            }

            return View(caseTheory);
        }

        // POST: CaseTheories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caseTheory = await _context.CaseTheories.FindAsync(id);
            _context.CaseTheories.Remove(caseTheory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseTheoryExists(int id)
        {
            return _context.CaseTheories.Any(e => e.Id == id);
        }
    }
}
