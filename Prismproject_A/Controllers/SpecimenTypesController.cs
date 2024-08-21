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
    public class SpecimenTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecimenTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpecimenTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpecimenTypes.ToListAsync());
        }

        // GET: SpecimenTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specimenTypes = await _context.SpecimenTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specimenTypes == null)
            {
                return NotFound();
            }

            return View(specimenTypes);
        }

        // GET: SpecimenTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpecimenTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SpecimenName,SpecimenType,Prefix,NumRows,NumCols")] SpecimenTypes specimenTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specimenTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specimenTypes);
        }

        // GET: SpecimenTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specimenTypes = await _context.SpecimenTypes.FindAsync(id);
            if (specimenTypes == null)
            {
                return NotFound();
            }
            return View(specimenTypes);
        }

        // POST: SpecimenTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SpecimenName,SpecimenType,Prefix,NumRows,NumCols")] SpecimenTypes specimenTypes)
        {
            if (id != specimenTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specimenTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecimenTypesExists(specimenTypes.Id))
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
            return View(specimenTypes);
        }

        // GET: SpecimenTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specimenTypes = await _context.SpecimenTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specimenTypes == null)
            {
                return NotFound();
            }

            return View(specimenTypes);
        }

        // POST: SpecimenTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specimenTypes = await _context.SpecimenTypes.FindAsync(id);
            if (specimenTypes != null)
            {
                _context.SpecimenTypes.Remove(specimenTypes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecimenTypesExists(int id)
        {
            return _context.SpecimenTypes.Any(e => e.Id == id);
        }
    }
}
