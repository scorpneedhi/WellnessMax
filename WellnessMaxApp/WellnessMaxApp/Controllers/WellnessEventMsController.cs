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
    public class WellnessEventMsController : Controller
    {
        private readonly WellnessMaxDbContext _context;

        public WellnessEventMsController(WellnessMaxDbContext context)
        {
            _context = context;
        }

        // GET: WellnessEventMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.WellnessEventMs.ToListAsync());
        }

        // GET: WellnessEventMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wellnessEventM = await _context.WellnessEventMs
                .FirstOrDefaultAsync(m => m.WellnessEventId == id);
            if (wellnessEventM == null)
            {
                return NotFound();
            }

            return View(wellnessEventM);
        }

        // GET: WellnessEventMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WellnessEventMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WellnessEventId,EventName,Venue,IsPaid,DateTimeUtc,Fee,TotalMembers,HostName,Description")] WellnessEventM wellnessEventM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wellnessEventM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wellnessEventM);
        }

        // GET: WellnessEventMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wellnessEventM = await _context.WellnessEventMs.FindAsync(id);
            if (wellnessEventM == null)
            {
                return NotFound();
            }
            return View(wellnessEventM);
        }

        // POST: WellnessEventMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WellnessEventId,EventName,Venue,IsPaid,DateTimeUtc,Fee,TotalMembers,HostName,Description")] WellnessEventM wellnessEventM)
        {
            if (id != wellnessEventM.WellnessEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wellnessEventM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WellnessEventMExists(wellnessEventM.WellnessEventId))
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
            return View(wellnessEventM);
        }

        // GET: WellnessEventMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wellnessEventM = await _context.WellnessEventMs
                .FirstOrDefaultAsync(m => m.WellnessEventId == id);
            if (wellnessEventM == null)
            {
                return NotFound();
            }

            return View(wellnessEventM);
        }

        // POST: WellnessEventMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wellnessEventM = await _context.WellnessEventMs.FindAsync(id);
            _context.WellnessEventMs.Remove(wellnessEventM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WellnessEventMExists(int id)
        {
            return _context.WellnessEventMs.Any(e => e.WellnessEventId == id);
        }
    }
}
