using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prismproject_A.Data;
using Prismproject_A.Models;

namespace Prismproject_A.Controllers
{
    public class BoxLocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoxLocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BoxLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.BoxLocations.ToListAsync());
        }

        // GET: BoxLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxLocations = await _context.BoxLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boxLocations == null)
            {
                return NotFound();
            }

            return View(boxLocations);
        }

        // GET: BoxLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoxLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoxNumber,Freezername,Compartment,Rack,Position")] BoxLocations boxLocations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boxLocations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boxLocations);
        }

        // GET: BoxLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxLocations = await _context.BoxLocations.FindAsync(id);
            if (boxLocations == null)
            {
                return NotFound();
            }
            return View(boxLocations);
        }

        // POST: BoxLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoxNumber,Freezername,Compartment,Rack,Position")] BoxLocations boxLocations)
        {
            if (id != boxLocations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boxLocations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoxLocationsExists(boxLocations.Id))
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
            return View(boxLocations);
        }

        // GET: BoxLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxLocations = await _context.BoxLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boxLocations == null)
            {
                return NotFound();
            }

            return View(boxLocations);
        }

        // POST: BoxLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boxLocations = await _context.BoxLocations.FindAsync(id);
            if (boxLocations != null)
            {
                _context.BoxLocations.Remove(boxLocations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoxLocationsExists(int id)
        {
            return _context.BoxLocations.Any(e => e.Id == id);
        }
    }
}
