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
    public class FreezerDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FreezerDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FreezerDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.FreezerDetails.ToListAsync());
        }

        // GET: FreezerDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezerDetails = await _context.FreezerDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (freezerDetails == null)
            {
                return NotFound();
            }

            return View(freezerDetails);
        }

        // GET: FreezerDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FreezerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Freezername,Compartment,Rack,Position")] FreezerDetails freezerDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freezerDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(freezerDetails);
        }

        // GET: FreezerDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezerDetails = await _context.FreezerDetails.FindAsync(id);
            if (freezerDetails == null)
            {
                return NotFound();
            }
            return View(freezerDetails);
        }

        // POST: FreezerDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Freezername,Compartment,Rack,Position")] FreezerDetails freezerDetails)
        {
            if (id != freezerDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freezerDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreezerDetailsExists(freezerDetails.Id))
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
            return View(freezerDetails);
        }

        // GET: FreezerDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezerDetails = await _context.FreezerDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (freezerDetails == null)
            {
                return NotFound();
            }

            return View(freezerDetails);
        }

        // POST: FreezerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freezerDetails = await _context.FreezerDetails.FindAsync(id);
            if (freezerDetails != null)
            {
                _context.FreezerDetails.Remove(freezerDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FreezerDetailsExists(int id)
        {
            return _context.FreezerDetails.Any(e => e.Id == id);
        }
    }
}
