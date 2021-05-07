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
            var cc = applicationDbContext.FirstOrDefault();
            var phase = _context.Phases.Where(x => x.ConsumerClaimantId == cc.Id);
            var ph = phase.OrderByDescending(x => x.Id).Last();
            
            if(ph.NoticeOfArbitratorSelection == true)
            {
                ViewBag.phase = "Current Phase: Arbitrator Invitation.";
            }
            if(ph.NotificationOfFiling == true)
            {
                ViewBag.phase = "Current Phase: Initiation.";
            }
            if(ph.AppointmentOfArbitrator == true)
            {
                ViewBag.phase = "Current Phase: Arbitrator appointment phase.";
            }
            if(ph.ArbitratorsDisclosures == true)
            {
                ViewBag.phase = "Current Phase: Arbitrator invitation.";
            }
            if(ph.CompletionOfHearing == true)
            {
                ViewBag.phase = "Current Phase: Award.";
            }
            if(ph.SignedOathDocument == true)
            {
                ViewBag.phase = "Current Phase: Arbitrator invitation.";
            }
            if(ph.SchedulingOrder == true)
            {
                ViewBag.phase = "Current Phase: Hearing.";
            }
            if (ph.Schedule)
            {
                ViewBag.phase = "Current Phase: Hearing.";
            }
            if(ph == null)
            {
                ViewBag.phase = "Current phase unknown.";
            }
            var cci = applicationDbContext.FirstOrDefault();
            var notices = _context.Notices.Where(x => x.ConsumerClaimantId == cci.Id);
            var notice = notices.Where(x => x.NotificationOfFiling == true).OrderBy(x => x.Date).LastOrDefault();
            if(notice != null)
            {
                var dateTimeThis = notice.Date;
                var date = dateTimeThis.Date;
                var todayDateTime = DateTime.Now;
                var today = todayDateTime.Date;
                var TimespanInDays = today - date;
                var doubleDays = TimespanInDays.TotalDays;
                var stringDays = doubleDays.ToString();
                ViewBag.Days = "Your case has been active for " + stringDays + " days. There is no need to register your case again.";


            }
            else
            {
                ViewBag.Days = "";
            }
            
            var toDo = _context.ToDoItems.Where(x => x.ConsumerClaimantId == cci.Id).OrderBy(y => y.DueDate).FirstOrDefault();
            if(toDo != null)
            {
                var toDoItem = toDo.Item;
                var toDoItemDueDate = toDo.DueDate.Date;
                ViewBag.ToDo = ($"Your next to do item is :'{toDoItem}' Due on {toDoItemDueDate.Date}");
            }
            else
            {
                ViewBag.Todo = "You have nothing due at this time.";
            }



              
            
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> ManagePartiesInvolved()
        {

            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var applicationDbContext = _context.ConsumerClaimants.Where(n => n.IdentityUserId == userId);
            var parties = _context.PartiesInvolved;
            if (applicationDbContext.Equals(null))
            {
                return View("Create");
            }


            return View(await parties.ToListAsync());
        }

        public async Task<IActionResult> ManageArbitrators()
        {

            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var applicationDbContext = _context.ConsumerClaimants.Where(n => n.IdentityUserId == userId).FirstOrDefault();
            var theory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == applicationDbContext.Id).FirstOrDefault();
            var arbitrators = _context.Arbitrators.Where(x => x.CaseTheoryId == theory.Id);
            if (applicationDbContext.Equals(null))
            {
                return View("Create");
            }
            var preferencesSet = _context.PreferedArbitratorAttributes.Where(x => x.CaseTheoryId == theory.Id).FirstOrDefault();
            if(preferencesSet != null)
            {
                ViewBag.Preferences = "Preferences are set. Review or change them here.";
            }
            else
            {
                ViewBag.Preferences = "You have not set your preferences yet. Click here to learn more and set them.";
            }


            return View(await arbitrators.ToListAsync());
        }
        public async Task<IActionResult> ManageNotes()
        {

            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var applicationDbContext = _context.ConsumerClaimants.Where(n => n.IdentityUserId == userId).FirstOrDefault();
            var theory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == applicationDbContext.Id).FirstOrDefault();
            var notes = _context.GeneralNotes.Where(x => x.CaseTheoryId == theory.Id);
            if (applicationDbContext.Equals(null))
            {
                return View("Create");
            }


            return View(await notes.ToListAsync());
        }
        public async Task<IActionResult> ManageAffirmativeDefenses()
        {

            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var applicationDbContext = _context.ConsumerClaimants.Where(n => n.IdentityUserId == userId).FirstOrDefault();
            var theory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == applicationDbContext.Id).FirstOrDefault();
            var aDef = _context.AnticipatedAffirmativeDefenses.Where(x => x.CaseTheoryId == theory.Id);
            if (applicationDbContext.Equals(null))
            {
                return View("CreateAffirmativeDefense");
            }


            return View(await aDef.ToListAsync());
        }

        public async Task<IActionResult> ManageFactualTheories()
        {

            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var applicationDbContext = _context.ConsumerClaimants.Where(n => n.IdentityUserId == userId).FirstOrDefault();
            var theory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == applicationDbContext.Id).FirstOrDefault();
            var factualTheories = _context.FactualTheories.Where(x => x.CaseTheoryId == theory.Id);
            if (applicationDbContext.Equals(null))
            {
                return View("Create");
            }


            return View(await factualTheories.ToListAsync());
        }
        public async Task<IActionResult> ManageCase()
        {

            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var casetheory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
            if (casetheory.Equals(null))
            {
                return View("CreateCaseTheory");
            }

            return View(casetheory);
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
        public async Task<IActionResult> Edit()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();

            if (cc == null)
            {
                return NotFound();
            }

            return View(cc);
        }

        // POST: ConsumerClaimants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,PhoneNumber")] ConsumerClaimant consumerClaimant)
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

       

        [HttpPost, ActionName("CreateCaseTheory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCaseTheory([Bind("LawBroken,HowLawBroken,Perpetrator,Location,ProofOfIntent,InInitiation,InArbitratorInvitation,InArbitratiorAppointment,InPreliminaryHearing,InAward")] CaseTheory caseTheory)
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
        public async Task<IActionResult> NoticeList()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var applicationDbContext = _context.Notices.Where(n => n.ConsumerClaimantId == cc.Id);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult CreateNotice()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNotice([Bind("Type,From,Date,Content,NotificationOfFiling,NoticeOfArbitratorSelection,ArbitratorsDisclosures,SignedOathDocument,AppointmentOfArbitrator,Schedule,SchedulingOrder,CompletionOfHearing")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                var id = this.User.Identity;
                var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
                var userId = user.Id;
                var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                notice.ConsumerClaimantId = cc.Id;
                var phase = new Phase();
                phase.ConsumerClaimantId = cc.Id;
                var todo = new ToDoItem();
                todo.ConsumerClaimantId = cc.Id;


                _context.Add(notice);
                if(notice.NotificationOfFiling == true)
                {
                    phase.NotificationOfFiling = true;
                    todo.DueDate = notice.Date.AddDays(5);
                    todo.AlarmDate = notice.Date.AddDays(3);
                    todo.Item = "Respond to notice";
                    var todo2 = new ToDoItem();
                    todo2.ConsumerClaimantId = cc.Id;
                    todo2.DueDate = notice.Date.AddDays(5);
                    todo2.AlarmDate = notice.Date.AddDays(3);
                    todo2.Item = "Pay Fees.";
                    _context.Add(todo2);
                    _context.SaveChanges();
                    

                }
                if(notice.NoticeOfArbitratorSelection == true)
                {
                    phase.NoticeOfArbitratorSelection = true;
                    todo.DueDate = notice.Date.AddDays(5);
                    todo.AlarmDate = notice.Date.AddDays(3);
                    todo.Item = "Review arbitrators' conflicts of interest and make objection as soon as possible.";

                }
                if(notice.ArbitratorsDisclosures == true)
                {
                    phase.ArbitratorsDisclosures = true;
                    todo.DueDate = notice.Date.AddDays(5);
                    todo.DueDate = notice.Date.AddDays(3);
                    todo.Item = "Review arbitrators' disclosures and make objections.";
                    todo.ConsumerClaimantId = cc.Id;



                }
                if(notice.SignedOathDocument == true)
                {
                    phase.SignedOathDocument = true;
                    todo.Item = "Review Oath Documents.";
                    todo.DueDate = notice.Date.AddDays(5);
                    todo.AlarmDate = notice.Date.AddDays(3);
                    todo.ConsumerClaimantId = cc.Id;


                }
                if(notice.AppointmentOfArbitrator == true)
                {
                    phase.AppointmentOfArbitrator = true;
                    todo.Item = "Review and make objections to arbitrator selection";
                    todo.DueDate = notice.Date.AddDays(5);
                    todo.AlarmDate = notice.Date.AddDays(3);
                    var todo2 = new ToDoItem();
                    todo2.ConsumerClaimantId = cc.Id;
                    todo2.Item = "Prepare for hearing by gathering relevant information. Enter details in home page.";
                    todo2.DueDate = notice.Date.AddDays(5);
                    todo2.AlarmDate = notice.Date.AddDays(3);
                    _context.Add(todo2);
                    var todo3 = new ToDoItem();
                    todo3.ConsumerClaimantId = cc.Id;
                    todo3.DueDate = notice.Date.AddDays(5);
                    todo3.AlarmDate = notice.Date.AddDays(3);
                    todo3.Item = "Schedule hearing: will be accomplished with Arbitrator";
                    _context.Add(todo3);
                    var todo4 = new ToDoItem();
                    todo4.ConsumerClaimantId = cc.Id;
                    todo4.DueDate = notice.Date.AddDays(5);
                    todo.AlarmDate = notice.Date.AddDays(2);
                    todo.Item = "Locate stenographer and update participants of requirement, if necessary";
                    _context.Add(todo4);
                    _context.SaveChanges();


                }
                if(notice.Schedule == true)
                {
                    phase.Schedule = true;
                    todo.Item = "Hire Stenographer: and update stenographer and other parties as necessary";
                    todo.DueDate = notice.Date.AddDays(5);
                    todo.AlarmDate = notice.Date.AddDays(3);
                    var todo5 = new ToDoItem();
                    todo5.ConsumerClaimantId = cc.Id;
                    todo5.DueDate = notice.Date.AddDays(5);
                    todo5.AlarmDate = notice.Date.AddDays(3);
                    todo5.Item = "Review all necessary evidence and preparation for hearing. Prepare evidence binder.";
                    _context.Add(todo5);
                    _context.SaveChanges();



                    
                }
                if(notice.SchedulingOrder == true)
                {
                    phase.SchedulingOrder = true;
                    todo.Item = "Add Hearing date to todo items";
                    todo.DueDate = notice.Date;

                }
                if(notice.CompletionOfHearing == true)
                {
                    phase.CompletionOfHearing = true;
                    todo.Item = "Prepare written statements or arguments as necessary";
                    todo.DueDate = notice.Date.AddDays(3);
                    todo.AlarmDate = notice.Date.AddDays(1);
                    

                }
                _context.Add(todo);
                _context.Add(phase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(NoticeList));
        }
        public async Task<IActionResult> DeleteNotice(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .Include(n => n.ConsumerClaimant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("DeleteNotice")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNoticeConfirmed(int id)
        {
            var notice = await _context.Notices.FindAsync(id);
            _context.Notices.Remove(notice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteToDoItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItem = await _context.ToDoItems
                .Include(t => t.ConsumerClaimant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }

        // POST: ToDoItems/Delete/5
        [HttpPost, ActionName("DeleteToDoItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteToDoItemConfirmed(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ToDoList));
        }
        public async Task<IActionResult> EditFactualTheory(int? id)
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


        [HttpPost, ActionName("EditFactualTheory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFactualTheory(int id, [Bind("Id,CaseTheoryId,Name,Description,IsPrimary")] FactualTheory factualTheory)
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
                return RedirectToAction(nameof(ManageFactualTheories));
            }
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", factualTheory.CaseTheoryId);
            return RedirectToAction(nameof(ManageFactualTheories));
        }
        public IActionResult CreateFactualTheory()
        {

            return View(nameof(CreateFactualTheory));
        }

        // POST: FactualTheories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("CreateFactualTheory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFactualTheory([Bind("Name,Description,IsPrimary")] FactualTheory factualTheory)
        {
            if (ModelState.IsValid)
            {
                var id = this.User.Identity;
                var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
                var userId = user.Id;
                var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                var caseTheory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
                factualTheory.CaseTheoryId = caseTheory.Id;
                _context.Add(factualTheory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageFactualTheories));
            }
         
            return View(nameof(ManageFactualTheories));
        }
        public async Task<IActionResult> DeleteFactualTheory(int? id)
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
        public IActionResult CreateAffirmativeDefense()
        {
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id");
            return View();
        }


        [HttpPost, ActionName("CreateAffirmativeDefense")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAffirmativeDefense([Bind("Description,Neutralization")] AnticipatedAffirmativeDefense anticipatedAffirmativeDefense)
        {
            if (ModelState.IsValid)
            {
                var id = this.User.Identity;
                var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
                var userId = user.Id;
                var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                var caseTheory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
                anticipatedAffirmativeDefense.CaseTheoryId = caseTheory.Id;
                _context.Add(anticipatedAffirmativeDefense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageAffirmativeDefenses));
            }
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", anticipatedAffirmativeDefense.CaseTheoryId);
            return View(nameof(ManageAffirmativeDefenses));
        }


        [HttpPost, ActionName("DeleteFactualTheory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFactualTheoryConfirmed(int id)
        {
            var factualTheory = await _context.FactualTheories.FindAsync(id);
            _context.FactualTheories.Remove(factualTheory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageFactualTheories));
        }
        public async Task<IActionResult> DeleteAffirmativeDefense(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anticipatedAffirmativeDefense = await _context.AnticipatedAffirmativeDefenses
                .Include(a => a.CaseTheory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anticipatedAffirmativeDefense == null)
            {
                return NotFound();
            }

            return View(anticipatedAffirmativeDefense);
        }


        [HttpPost, ActionName("DeleteAffirmativeDefense")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAffirmativeDefenseConfirmed(int id)
        {
            var anticipatedAffirmativeDefense = await _context.AnticipatedAffirmativeDefenses.FindAsync(id);
            _context.AnticipatedAffirmativeDefenses.Remove(anticipatedAffirmativeDefense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageAffirmativeDefenses));
        }

        public async Task<IActionResult> EditAffirmativeDefense(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anticipatedAffirmativeDefense = await _context.AnticipatedAffirmativeDefenses.FindAsync(id);
            if (anticipatedAffirmativeDefense == null)
            {
                return NotFound();
            }
            return View(anticipatedAffirmativeDefense);
        }


        [HttpPost, ActionName("EditAffirmativeDefense")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAffirmativeDefense(int id, [Bind("Id,CaseTheoryId,Description,Neutralization")] AnticipatedAffirmativeDefense anticipatedAffirmativeDefense)
        {
        

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anticipatedAffirmativeDefense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnticipatedAffirmativeDefenseExists(anticipatedAffirmativeDefense.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ManageAffirmativeDefenses));
            }
          
            return View(nameof(ManageAffirmativeDefenses));
        }

        public IActionResult CreateNote()
        {

            return View();
        }


        [HttpPost, ActionName("CreateNote")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNote([Bind("Id,Date,Description")] GeneralNotes generalNotes)
        {
            if (ModelState.IsValid)
            {
                var id = this.User.Identity;
                var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
                var userId = user.Id;
                var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                var caseTheory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
                generalNotes.CaseTheoryId = caseTheory.Id;
                _context.Add(generalNotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageNotes));
            }
            return View(nameof(ManageNotes));
        }

        public async Task<IActionResult> EditNote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalNotes = await _context.GeneralNotes.FindAsync(id);
            if (generalNotes == null)
            {
                return NotFound();
            }
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", generalNotes.CaseTheoryId);
            return View(generalNotes);
        }


        [HttpPost, ActionName("EditNote")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNote(int id, [Bind("Id,CaseTheoryId,Date,Description")] GeneralNotes generalNotes)
        {
            if (id != generalNotes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalNotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralNotesExists(generalNotes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ManageNotes));
            }

            return View(nameof(ManageNotes));
        }
        public async Task<IActionResult> DeleteNote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalNotes = await _context.GeneralNotes
                .Include(g => g.CaseTheory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generalNotes == null)
            {
                return NotFound();
            }

            return View(generalNotes);
        }


        [HttpPost, ActionName("DeleteNote")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNoteConfirmed(int id)
        {
            var generalNotes = await _context.GeneralNotes.FindAsync(id);
            _context.GeneralNotes.Remove(generalNotes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageNotes));
        }
        public async Task<IActionResult> ContactDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyInvolved = await _context.PartiesInvolved
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partyInvolved == null)
            {
                return NotFound();
            }

            return View(partyInvolved);
        }

        // GET: PartyInvolveds/Create
        public IActionResult CreateContact()
        {
            return View();
        }


        [HttpPost, ActionName("CreateContact")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContact([Bind("Id,FirstName,LastName,Phone,Address,City,State,Company,Role")] PartyInvolved partyInvolved)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partyInvolved);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManagePartiesInvolved));
            }
            return View(partyInvolved);
        }

        // GET: PartyInvolveds/Edit/5
        public async Task<IActionResult> EditContact(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyInvolved = await _context.PartiesInvolved.FindAsync(id);
            if (partyInvolved == null)
            {
                return NotFound();
            }
            return View(partyInvolved);
        }


        [HttpPost, ActionName("EditContact")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContact(int id, [Bind("Id,FirstName,LastName,Phone,Address,City,State,Company,Role")] PartyInvolved partyInvolved)
        {
            if (id != partyInvolved.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partyInvolved);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyInvolvedExists(partyInvolved.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ManagePartiesInvolved));
            }
            return View(partyInvolved);
        }


        public async Task<IActionResult> DeleteContact(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyInvolved = await _context.PartiesInvolved
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partyInvolved == null)
            {
                return NotFound();
            }

            return View(partyInvolved);
        }
        public IActionResult ArbitratorPreferences()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction(nameof(Create));
            }
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var caseTheory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
            var preferences = _context.PreferedArbitratorAttributes.Where(x => x.CaseTheoryId == caseTheory.Id).FirstOrDefault();
            if (preferences == null)
            {
                return View(nameof(CreateArbiterPreferences));
            }



            return View(preferences);
        }
        public IActionResult CreateArbiterPreferences()
        {
         
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArbiterPreferences([Bind("VocationalIndustry,AwardsToCompanies,AwardsToClaimants,LegalExperience,RelationshipsWithParties,HasStockInCompany,DescriptionOfCOI")] PreferencesForArbitrator preferencesForArbitrator)
        {
            if (ModelState.IsValid)
            {
                var id = this.User.Identity;
                var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
                if (user == null)
                {
                    return RedirectToAction(nameof(Create));
                }
                var userId = user.Id;
                var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                var caseTheory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
                preferencesForArbitrator.CaseTheoryId = caseTheory.Id;
                _context.Add(preferencesForArbitrator);
                var comparer = new Arbitrator();
                comparer.FirstName = "MyPreferences";
                comparer.DescriptionOfCOI = preferencesForArbitrator.DescriptionOfCOI;
                comparer.AwardsToClaimants = preferencesForArbitrator.AwardsToClaimants;
                comparer.AwardsToCompanies = preferencesForArbitrator.AwardsToCompanies;
                comparer.HasStockInCompany = preferencesForArbitrator.HasStockInCompany;
                comparer.RelationshipsWithParties = preferencesForArbitrator.RelationshipsWithParties;
                comparer.VocationalIndustry = preferencesForArbitrator.VocationalIndustry;
                comparer.CaseTheoryId = preferencesForArbitrator.CaseTheoryId;
                _context.Add(comparer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ArbitratorPreferences));
            }
            return RedirectToAction(nameof(ArbitratorPreferences));
        }
        public async Task<IActionResult> EditArbitratorPreferences(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preferencesForArbitrator = await _context.PreferedArbitratorAttributes.FindAsync(id);
            if (preferencesForArbitrator == null)
            {
                return NotFound();
            }
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", preferencesForArbitrator.CaseTheoryId);
            return View(preferencesForArbitrator);
        }


        [HttpPost, ActionName("EditArbitratorPreferences")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditArbitratorPreferences(int id, [Bind("Id,CaseTheoryId,VocationalIndustry,AwardsToCompanies,AwardsToClaimants,LegalExperience,RelationshipsWithParties,HasStockInCompany,DescriptionOfCOI")] PreferencesForArbitrator preferencesForArbitrator)
        {
            if (id != preferencesForArbitrator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preferencesForArbitrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreferencesForArbitratorExists(preferencesForArbitrator.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ArbitratorPreferences));
            }
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", preferencesForArbitrator.CaseTheoryId);
            return View(preferencesForArbitrator);
        }

  
        [HttpPost, ActionName("DeleteContact")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContactConfirmed(int id)
        {
            var partyInvolved = await _context.PartiesInvolved.FindAsync(id);
            _context.PartiesInvolved.Remove(partyInvolved);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManagePartiesInvolved));
        }
        public async Task<IActionResult> ArbitratorOptions()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction(nameof(Create));
            }
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var caseTheory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
            var arbitrators = _context.Arbitratorss.Where(x => x.CaseTheoryId == caseTheory.Id);
            return View(await arbitrators.ToListAsync());
        }
        public IActionResult CreateArbitrator()
        {
         
            return View();
        }


        [HttpPost("CreateArbitrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArbitrator([Bind("FirstName,LastName,Points,VocationalIndustry,AwardsToCompanies,AwardsToClaimants,LegalExperience,IsSelected,RelationshipsWithParties,HasStockInCompany,DescriptionOfCOI")] Arbitrator arbiter)
        {
            if (ModelState.IsValid)
            {
                var id = this.User.Identity;
                var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
                if (user == null)
                {
                    return RedirectToAction(nameof(Create));
                }
                var userId = user.Id;
                var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
                var caseTheory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
                arbiter.CaseTheoryId = caseTheory.Id;
                _context.Add(arbiter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ArbitratorOptions));
            }
         
            return RedirectToAction(nameof(ArbitratorOptions));
        }
        public async Task<IActionResult> EditArbitrator(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arbiter = await _context.Arbitratorss.FindAsync(id);
            if (arbiter == null)
            {
                return NotFound();
            }
            ViewData["CaseTheoryId"] = new SelectList(_context.CaseTheories, "Id", "Id", arbiter.CaseTheoryId);
            return View(arbiter);
        }


        [HttpPost, ActionName("EditArbitrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditArbitrator(int id, [Bind("Id,FirstName,LastName,CaseTheoryId,Points,VocationalIndustry,AwardsToCompanies,AwardsToClaimants,LegalExperience,IsSelected,RelationshipsWithParties,HasStockInCompany,DescriptionOfCOI")] Arbitrator arbiter)
        {
            if (id != arbiter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arbiter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArbiterExists(arbiter.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ArbitratorOptions));
            }

            return View(nameof(ArbitratorOptions));
        }
        public async Task<IActionResult> DeleteArbitrator(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arbiter = await _context.Arbitratorss
                .Include(a => a.CaseTheory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arbiter == null)
            {
                return NotFound();
            }

            return View(arbiter);
        }


        [HttpPost, ActionName("DeleteArbitrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteArbitratorConfirmed(int id)
        {
            var arbiter = await _context.Arbitratorss.FindAsync(id);
            _context.Arbitratorss.Remove(arbiter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ArbitratorOptions));
        }
        public async Task<IActionResult> ArbitratorDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arbiter = await _context.Arbitratorss
                .Include(a => a.CaseTheory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arbiter == null)
            {
                return NotFound();
            }

            return View(arbiter);
        }
        public async Task<IActionResult> CompareArbitrators()
        {
            var id = this.User.Identity;
            var user = _context.Users.Where(x => x.UserName == id.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction(nameof(Create));
            }
            var userId = user.Id;
            var cc = _context.ConsumerClaimants.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var caseTheory = _context.CaseTheories.Where(x => x.ConsumerClaimantId == cc.Id).FirstOrDefault();
            var arbitrators = _context.Arbitratorss.Where(x => x.CaseTheoryId == caseTheory.Id).Select(f => f.FirstName).AsEnumerable();



            ViewBag.Arbitrators = new SelectList(arbitrators);
           
       
            return View();
        }
        

        [HttpPost, ActionName("CompareArbitratorsC")]
        public ActionResult CompareArbitratorDetails([Bind("ArbitratorName,SecondArbitratorName")] NamesViewModel names)
        {
            var arbitrator = _context.Arbitratorss.Where(x => x.FirstName == names.ArbitratorName).ToList();
            var arbitratorTwo = _context.Arbitratorss.Where(x => x.FirstName == names.SecondArbitratorName).FirstOrDefault();
            arbitrator.Add(arbitratorTwo);

            return View(arbitrator);
        }
   
        public async Task<IActionResult> ArbitratorDetailsPartial(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arbiter = await _context.Arbitrators
                .Include(a => a.CaseTheory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arbiter == null)
            {
                return NotFound();
            }

            return View(arbiter);
        }


        private bool PartyInvolvedExists(int id)
        {
            return _context.PartiesInvolved.Any(e => e.Id == id);
        }
    
    private bool AnticipatedAffirmativeDefenseExists(int id)
        {
            return _context.AnticipatedAffirmativeDefenses.Any(e => e.Id == id);
        }


        private bool ToDoItemExists(int id)
        {
            return _context.ToDoItems.Any(e => e.Id == id);
        }


        private bool NoticeExists(int id)
        {
            return _context.Notices.Any(e => e.Id == id);
        }

        private bool ConsumerClaimantExists(int id)
        {
            return _context.ConsumerClaimants.Any(e => e.Id == id);
        }
        private bool CaseTheoryExists(int id)
        {
            return _context.CaseTheories.Any(e => e.Id == id);
        }
        private bool FactualTheoryExists(int id)
        {
            return _context.FactualTheories.Any(e => e.Id == id);
        }
        private bool GeneralNotesExists(int id)
        {
            return _context.GeneralNotes.Any(e => e.Id == id);
        }
        private bool PreferencesForArbitratorExists(int id)
        {
            return _context.PreferedArbitratorAttributes.Any(e => e.Id == id);
        }
        private bool ArbiterExists(int id)
        {
            return _context.Arbitrators.Any(e => e.Id == id);
        }

    }
}
