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
    public class ConsumerClaimantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsumerClaimantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConsumerClaimants
        public async Task<IActionResult> Index()
        {

            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var applicationDbContext = _context.ConsumerClaimants.Where(n => n.IdentityUserId == userId);
            if (applicationDbContext.Equals(null))
            {
                return View("Create");
            }
              
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ConsumerClaimants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumerClaimant = await _context.ConsumerClaimants
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumerClaimant == null)
            {
                return NotFound();
            }

            return View(consumerClaimant);
        }

        // GET: ConsumerClaimants/Create
        public IActionResult Create()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var applicationDbContext = _context.ConsumerClaimants.Where(n => n.IdentityUserId == userId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ConsumerClaimants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdentityUserId,FirstName,LastName,PhoneNumber,InArbitration,CompanyDisputing,ArbitrationLocation")] ConsumerClaimant consumerClaimant)
        {
            if (ModelState.IsValid)
            {
                var id = this.User.Identity;
                var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
                var userId = user.Id;
                consumerClaimant.IdentityUserId = user.Id;
                _context.Add(consumerClaimant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", consumerClaimant.IdentityUserId);
            return View(consumerClaimant);
        }

        // GET: ConsumerClaimants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumerClaimant = await _context.ConsumerClaimants.FindAsync(id);
            if (consumerClaimant == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", consumerClaimant.IdentityUserId);
            return View(consumerClaimant);
        }

        // POST: ConsumerClaimants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,PhoneNumber,InArbitration,CompanyDisputing,ArbitrationLocation")] ConsumerClaimant consumerClaimant)
        {
            if (id != consumerClaimant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumerClaimant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumerClaimantExists(consumerClaimant.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", consumerClaimant.IdentityUserId);
            return View(consumerClaimant);
        }

        // GET: ConsumerClaimants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumerClaimant = await _context.ConsumerClaimants
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumerClaimant == null)
            {
                return NotFound();
            }

            return View(consumerClaimant);
        }

        // POST: ConsumerClaimants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumerClaimant = await _context.ConsumerClaimants.FindAsync(id);
            _context.ConsumerClaimants.Remove(consumerClaimant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CaseTheoryDetails()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var ccId = cc.Id;

            var idCS = _context.CaseTheories.Where(x => x.ConsumerClaimantId == ccId).FirstOrDefault();
            if (idCS == null)
            {
                return NotFound();
            }

            var caseTheory = await _context.CaseTheories
                .Include(c => c.ConsumerClaimant)
                .FirstOrDefaultAsync(m => m.Id == idCS.Id);
            if (caseTheory == null)
            {
                return NotFound();
            }

            return View(caseTheory);
        }
        public IActionResult CreateCaseTheory()
        {
            ViewData["ConsumerClaimantId"] = new SelectList(_context.ConsumerClaimants, "Id", "Id");
            return View();
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCaseTheory([Bind("Id,LawBroken,HowLawBroken,Perpetrator,Location,ProofOfIntent,InInitiation,InArbitratorInvitation,InArbitratiorAppointment,InPreliminaryHearing,InAward")] CaseTheory caseTheory)
        {
            if (ModelState.IsValid)
            {
                var id = this.User.Identity;
                var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
                var userId = user.Id;
                var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                caseTheory.ConsumerClaimantId = cc.Id;
                _context.Add(caseTheory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View("Index");
        }
        public async Task<IActionResult> EditCaseTheory()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var cTID = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();

            if (cTID == null)
            {
                return NotFound();
            }

            var caseTheory = await _context.CaseTheories.FindAsync(cTID.Id);
            if (caseTheory == null)
            {
                return NotFound();
            }
       
            return View(caseTheory);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCaseTheory(int id, [Bind("Id,LawBroken,HowLawBroken,Perpetrator,Location,ProofOfIntent,InInitiation,InArbitratorInvitation,InArbitratiorAppointment,InPreliminaryHearing,InAward")] CaseTheory caseTheory)
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
        public IActionResult CreateCaseTheme()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var theory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCaseTheme([Bind("Id,ArbiterChair,CoreTruth")] CaseTheme caseTheme)
        {
            if (ModelState.IsValid)
            {
                var id = this.User.Identity;
                var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
                var userId = user.Id;
                var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                var theory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
                caseTheme.CaseTheoryId = theory.Id;
                _context.Add(caseTheme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View("Index");
        }
        public async Task<IActionResult> FactualTheory()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var theory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
            var applicationDbContext = _context.FactualTheories.Include(f => f.CaseTheoryId == theory.Id);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> ToDoList()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var applicationDbContext = _context.ToDoItems.Where(t => t.ConsumerClaimantId == cc.Id);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult AddToDoItem()
        {
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToDoItem([Bind("Item,DateReceived,DueDate,AlarmDate")] ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                var id = this.User.Identity;
                var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
                var userId = user.Id;
                var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                toDoItem.ConsumerClaimantId = cc.Id;
                _context.Add(toDoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ToDoList));
            }

            return RedirectToAction(nameof(ToDoList));
        }

        private bool ConsumerClaimantExists(int id)
        {
            return _context.ConsumerClaimants.Any(e => e.Id == id);
        }
        private bool CaseTheoryExists(int id)
        {
            return _context.CaseTheories.Any(e => e.Id == id);
        }

    }
}
