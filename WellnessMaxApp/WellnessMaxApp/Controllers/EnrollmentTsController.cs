#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WellnessMaxApp.Repository;
using WellnessMaxApp.Repository.Models;

namespace WellnessMaxApp.Controllers
{
    public class EnrollmentTsController : Controller
    {
        private readonly WellnessMaxDbContext _context;

        public EnrollmentTsController(WellnessMaxDbContext context)
        {
            _context = context;
        }

        // GET: EnrollmentTs
        public async Task<IActionResult> Index()
        {
            var wellnessMaxDbContext = _context.EnrollmentTs.Include(e => e.Customer).Include(e => e.OnlineCounseling).Include(e => e.WellnessEvent).Include(e => e.WellnessProgram);
            return View(await wellnessMaxDbContext.ToListAsync());
        }

        // GET: EnrollmentTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentT = await _context.EnrollmentTs
                .Include(e => e.Customer)
                .Include(e => e.OnlineCounseling)
                .Include(e => e.WellnessEvent)
                .Include(e => e.WellnessProgram)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollmentT == null)
            {
                return NotFound();
            }

            return View(enrollmentT);
        }

        // GET: EnrollmentTs/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.CustomerMs, "CustomerId", "CustomerId");
            ViewData["OnlineCounselingId"] = new SelectList(_context.OnlineCounselingMs, "OnlineCounselingId", "OnlineCounselingId");
            ViewData["WellnessEventId"] = new SelectList(_context.WellnessEventMs, "WellnessEventId", "WellnessEventId");
            ViewData["WellnessProgramId"] = new SelectList(_context.WellnessProgramMs, "WellnessProgramId", "WellnessProgramId");
            return View();
        }

        // POST: EnrollmentTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,OnlineCounselingId,WellnessEventId,WellnessProgramId,CustomerId,PaymentStatus")] EnrollmentT enrollmentT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollmentT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.CustomerMs, "CustomerId", "CustomerId", enrollmentT.CustomerId);
            ViewData["OnlineCounselingId"] = new SelectList(_context.OnlineCounselingMs, "OnlineCounselingId", "OnlineCounselingId", enrollmentT.OnlineCounselingId);
            ViewData["WellnessEventId"] = new SelectList(_context.WellnessEventMs, "WellnessEventId", "WellnessEventId", enrollmentT.WellnessEventId);
            ViewData["WellnessProgramId"] = new SelectList(_context.WellnessProgramMs, "WellnessProgramId", "WellnessProgramId", enrollmentT.WellnessProgramId);
            return View(enrollmentT);
        }

        // GET: EnrollmentTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentT = await _context.EnrollmentTs.FindAsync(id);
            if (enrollmentT == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.CustomerMs, "CustomerId", "CustomerId", enrollmentT.CustomerId);
            ViewData["OnlineCounselingId"] = new SelectList(_context.OnlineCounselingMs, "OnlineCounselingId", "OnlineCounselingId", enrollmentT.OnlineCounselingId);
            ViewData["WellnessEventId"] = new SelectList(_context.WellnessEventMs, "WellnessEventId", "WellnessEventId", enrollmentT.WellnessEventId);
            ViewData["WellnessProgramId"] = new SelectList(_context.WellnessProgramMs, "WellnessProgramId", "WellnessProgramId", enrollmentT.WellnessProgramId);
            return View(enrollmentT);
        }

        // POST: EnrollmentTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId,OnlineCounselingId,WellnessEventId,WellnessProgramId,CustomerId,PaymentStatus")] EnrollmentT enrollmentT)
        {
            if (id != enrollmentT.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollmentT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentTExists(enrollmentT.EnrollmentId))
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
            ViewData["CustomerId"] = new SelectList(_context.CustomerMs, "CustomerId", "CustomerId", enrollmentT.CustomerId);
            ViewData["OnlineCounselingId"] = new SelectList(_context.OnlineCounselingMs, "OnlineCounselingId", "OnlineCounselingId", enrollmentT.OnlineCounselingId);
            ViewData["WellnessEventId"] = new SelectList(_context.WellnessEventMs, "WellnessEventId", "WellnessEventId", enrollmentT.WellnessEventId);
            ViewData["WellnessProgramId"] = new SelectList(_context.WellnessProgramMs, "WellnessProgramId", "WellnessProgramId", enrollmentT.WellnessProgramId);
            return View(enrollmentT);
        }

        // GET: EnrollmentTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentT = await _context.EnrollmentTs
                .Include(e => e.Customer)
                .Include(e => e.OnlineCounseling)
                .Include(e => e.WellnessEvent)
                .Include(e => e.WellnessProgram)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollmentT == null)
            {
                return NotFound();
            }

            return View(enrollmentT);
        }

        // POST: EnrollmentTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollmentT = await _context.EnrollmentTs.FindAsync(id);
            _context.EnrollmentTs.Remove(enrollmentT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentTExists(int id)
        {
            return _context.EnrollmentTs.Any(e => e.EnrollmentId == id);
        }
    }
}
