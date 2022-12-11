using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Data;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class EventAttendanceController : Controller
    {
        private readonly EventsContext _context;

        public EventAttendanceController(EventsContext context)
        {
            _context = context;
        }

        // GET: EventAttendance
        public async Task<IActionResult> Index()
        {
            var eventsContext = _context.Attendances.Include(e => e.Event).Include(e => e.User);
            return View(await eventsContext.ToListAsync());
        }

        // GET: EventAttendance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var eventAttendance = await _context.Attendances
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventAttendance == null)
            {
                return NotFound();
            }

            return View(eventAttendance);
        }

        // GET: EventAttendance/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Location");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: EventAttendance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,UserId,Status")] EventAttendance eventAttendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventAttendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Location", eventAttendance.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", eventAttendance.UserId);
            return View(eventAttendance);
        }

        // GET: EventAttendance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var eventAttendance = await _context.Attendances.FindAsync(id);
            if (eventAttendance == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Location", eventAttendance.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", eventAttendance.UserId);
            return View(eventAttendance);
        }

        // POST: EventAttendance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,UserId,Status")] EventAttendance eventAttendance)
        {
            if (id != eventAttendance.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventAttendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventAttendanceExists(eventAttendance.EventId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Location", eventAttendance.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", eventAttendance.UserId);
            return View(eventAttendance);
        }

        // GET: EventAttendance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var eventAttendance = await _context.Attendances
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventAttendance == null)
            {
                return NotFound();
            }

            return View(eventAttendance);
        }

        // POST: EventAttendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attendances == null)
            {
                return Problem("Entity set 'EventsContext.Attendances'  is null.");
            }
            var eventAttendance = await _context.Attendances.FindAsync(id);
            if (eventAttendance != null)
            {
                _context.Attendances.Remove(eventAttendance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventAttendanceExists(int id)
        {
          return _context.Attendances.Any(e => e.EventId == id);
        }
    }
}
