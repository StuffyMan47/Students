using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.DataBase;
using Students.DataBase.Domain;

namespace Students.Controllers
{
    public class EstimatesController : Controller
    {
        private readonly AppDBContext _context;

        public EstimatesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Estimates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estimates.ToListAsync());
        }

        // GET: Estimates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estimate = await _context.Estimates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estimate == null)
            {
                return NotFound();
            }

            return View(estimate);
        }

        // GET: Estimates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estimates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value,Date")] Estimate estimate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estimate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estimate);
        }

        // GET: Estimates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estimate = await _context.Estimates.FindAsync(id);
            if (estimate == null)
            {
                return NotFound();
            }
            return View(estimate);
        }

        // POST: Estimates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Value,Date")] Estimate estimate)
        {
            if (id != estimate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estimate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstimateExists(estimate.Id))
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
            return View(estimate);
        }

        // GET: Estimates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estimate = await _context.Estimates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estimate == null)
            {
                return NotFound();
            }

            return View(estimate);
        }

        // POST: Estimates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estimate = await _context.Estimates.FindAsync(id);
            if (estimate != null)
            {
                _context.Estimates.Remove(estimate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstimateExists(int id)
        {
            return _context.Estimates.Any(e => e.Id == id);
        }
    }
}
