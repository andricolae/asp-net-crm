using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crm.Data;
using crm.Models;
using Microsoft.AspNetCore.Authorization;

namespace crm.Controllers
{
    public class ComplaintsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComplaintsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Complaints
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.Complaints != null ? 
                          View(await _context.Complaints.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Complaints'  is null.");
        }

        // GET: Complaints/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Complaints == null)
            {
                return NotFound();
            }

            var complaints = await _context.Complaints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (complaints == null)
            {
                return NotFound();
            }

            return View(complaints);
        }

        // GET: Complaints/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Complaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,CompanyId,Description,Status")] Complaints complaints)
        {
            if (ModelState.IsValid)
            {
                _context.Add(complaints);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complaints);
        }

        // GET: Complaints/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Complaints == null)
            {
                return NotFound();
            }

            var complaints = await _context.Complaints.FindAsync(id);
            if (complaints == null)
            {
                return NotFound();
            }
            return View(complaints);
        }

        // POST: Complaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,CompanyId,Description,Status")] Complaints complaints)
        {
            if (id != complaints.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complaints);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplaintsExists(complaints.Id))
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
            return View(complaints);
        }

        // GET: Complaints/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Complaints == null)
            {
                return NotFound();
            }

            var complaints = await _context.Complaints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (complaints == null)
            {
                return NotFound();
            }

            return View(complaints);
        }

        // POST: Complaints/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Complaints == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Complaints'  is null.");
            }
            var complaints = await _context.Complaints.FindAsync(id);
            if (complaints != null)
            {
                _context.Complaints.Remove(complaints);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplaintsExists(int id)
        {
          return (_context.Complaints?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
