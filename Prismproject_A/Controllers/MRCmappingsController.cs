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
    public class MRCmappingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MRCmappingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MRCmappings
        public async Task<IActionResult> Index()
        {
            return View(await _context.MRCmapping.ToListAsync());
        }

        // GET: MRCmappings/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mRCmapping = await _context.MRCmapping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mRCmapping == null)
            {
                return NotFound();
            }

            return View(mRCmapping);
        }

        // GET: MRCmappings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MRCmappings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mrc,Code")] MRCmapping mRCmapping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mRCmapping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mRCmapping);
        }

        // GET: MRCmappings/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mRCmapping = await _context.MRCmapping.FindAsync(id);
            if (mRCmapping == null)
            {
                return NotFound();
            }
            return View(mRCmapping);
        }

        // POST: MRCmappings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,Mrc,Code")] MRCmapping mRCmapping)
        {
            if (id != mRCmapping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mRCmapping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MRCmappingExists(mRCmapping.Id))
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
            return View(mRCmapping);
        }

        // GET: MRCmappings/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mRCmapping = await _context.MRCmapping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mRCmapping == null)
            {
                return NotFound();
            }

            return View(mRCmapping);
        }

        // POST: MRCmappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var mRCmapping = await _context.MRCmapping.FindAsync(id);
            if (mRCmapping != null)
            {
                _context.MRCmapping.Remove(mRCmapping);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MRCmappingExists(byte id)
        {
            return _context.MRCmapping.Any(e => e.Id == id);
        }
    }
}
