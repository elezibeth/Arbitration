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
        public async Task<IActionResult> Details(int? id)
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
        public IActionResult Create()
        {
            ViewData["ConsumerClaimantId"] = new SelectList(_context.ConsumerClaimants, "Id", "Id");
            return View();
        }

        // POST: CaseTheories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConsumerClaimantId,LawBroken,HowLawBroken,Perpetrator,Location,ProofOfIntent,InInitiation,InArbitratorInvitation,InArbitratiorAppointment,InPreliminaryHearing,InAward")] CaseTheory caseTheory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caseTheory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsumerClaimantId"] = new SelectList(_context.ConsumerClaimants, "Id", "Id", caseTheory.ConsumerClaimantId);
            return View(caseTheory);
        }

        // GET: CaseTheories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseTheory = await _context.CaseTheories.FindAsync(id);
            if (caseTheory == null)
            {
                return NotFound();
            }
            ViewData["ConsumerClaimantId"] = new SelectList(_context.ConsumerClaimants, "Id", "Id", caseTheory.ConsumerClaimantId);
            return View(caseTheory);
        }

        // POST: CaseTheories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConsumerClaimantId,LawBroken,HowLawBroken,Perpetrator,Location,ProofOfIntent,InInitiation,InArbitratorInvitation,InArbitratiorAppointment,InPreliminaryHearing,InAward")] CaseTheory caseTheory)
        {
            if (id != caseTheory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseTheory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseTheoryExists(caseTheory.Id))
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
            ViewData["ConsumerClaimantId"] = new SelectList(_context.ConsumerClaimants, "Id", "Id", caseTheory.ConsumerClaimantId);
            return View(caseTheory);
        }

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
