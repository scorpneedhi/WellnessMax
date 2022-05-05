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
    public class WellnessProgramMsController : Controller
    {
        private readonly WellnessMaxDbContext _context;

        public WellnessProgramMsController(WellnessMaxDbContext context)
        {
            _context = context;
        }

        // GET: WellnessProgramMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.WellnessProgramMs.ToListAsync());
        }

        // GET: WellnessProgramMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wellnessProgramM = await _context.WellnessProgramMs
                .FirstOrDefaultAsync(m => m.WellnessProgramId == id);
            if (wellnessProgramM == null)
            {
                return NotFound();
            }

            return View(wellnessProgramM);
        }

        // GET: WellnessProgramMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WellnessProgramMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WellnessProgramId,WellnessProgramName,Venue,IsPaid,DateTimeUtc,Fee,TotalMembers,DurationInHours,HostName,Description")] WellnessProgramM wellnessProgramM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wellnessProgramM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wellnessProgramM);
        }

        // GET: WellnessProgramMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wellnessProgramM = await _context.WellnessProgramMs.FindAsync(id);
            if (wellnessProgramM == null)
            {
                return NotFound();
            }
            return View(wellnessProgramM);
        }

        // POST: WellnessProgramMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WellnessProgramId,WellnessProgramName,Venue,IsPaid,DateTimeUtc,Fee,TotalMembers,DurationInHours,HostName,Description")] WellnessProgramM wellnessProgramM)
        {
            if (id != wellnessProgramM.WellnessProgramId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wellnessProgramM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WellnessProgramMExists(wellnessProgramM.WellnessProgramId))
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
            return View(wellnessProgramM);
        }

        // GET: WellnessProgramMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wellnessProgramM = await _context.WellnessProgramMs
                .FirstOrDefaultAsync(m => m.WellnessProgramId == id);
            if (wellnessProgramM == null)
            {
                return NotFound();
            }

            return View(wellnessProgramM);
        }

        // POST: WellnessProgramMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wellnessProgramM = await _context.WellnessProgramMs.FindAsync(id);
            _context.WellnessProgramMs.Remove(wellnessProgramM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WellnessProgramMExists(int id)
        {
            return _context.WellnessProgramMs.Any(e => e.WellnessProgramId == id);
        }
    }
}
