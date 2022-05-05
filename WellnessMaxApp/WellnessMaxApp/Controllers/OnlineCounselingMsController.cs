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
    public class OnlineCounselingMsController : Controller
    {
        private readonly WellnessMaxDbContext _context;

        public OnlineCounselingMsController(WellnessMaxDbContext context)
        {
            _context = context;
        }

        // GET: OnlineCounselingMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.OnlineCounselingMs.ToListAsync());
        }

        // GET: OnlineCounselingMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineCounselingM = await _context.OnlineCounselingMs
                .FirstOrDefaultAsync(m => m.OnlineCounselingId == id);
            if (onlineCounselingM == null)
            {
                return NotFound();
            }

            return View(onlineCounselingM);
        }

        // GET: OnlineCounselingMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OnlineCounselingMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OnlineCounselingId,OnlineCounselingName,Venue,IsPaid,Fee,TotalMembers,HostName,Description,DateTimeUtc")] OnlineCounselingM onlineCounselingM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onlineCounselingM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(onlineCounselingM);
        }

        // GET: OnlineCounselingMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineCounselingM = await _context.OnlineCounselingMs.FindAsync(id);
            if (onlineCounselingM == null)
            {
                return NotFound();
            }
            return View(onlineCounselingM);
        }

        // POST: OnlineCounselingMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OnlineCounselingId,OnlineCounselingName,Venue,IsPaid,Fee,TotalMembers,HostName,Description,DateTimeUtc")] OnlineCounselingM onlineCounselingM)
        {
            if (id != onlineCounselingM.OnlineCounselingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onlineCounselingM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnlineCounselingMExists(onlineCounselingM.OnlineCounselingId))
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
            return View(onlineCounselingM);
        }

        // GET: OnlineCounselingMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineCounselingM = await _context.OnlineCounselingMs
                .FirstOrDefaultAsync(m => m.OnlineCounselingId == id);
            if (onlineCounselingM == null)
            {
                return NotFound();
            }

            return View(onlineCounselingM);
        }

        // POST: OnlineCounselingMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var onlineCounselingM = await _context.OnlineCounselingMs.FindAsync(id);
            _context.OnlineCounselingMs.Remove(onlineCounselingM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnlineCounselingMExists(int id)
        {
            return _context.OnlineCounselingMs.Any(e => e.OnlineCounselingId == id);
        }
    }
}
