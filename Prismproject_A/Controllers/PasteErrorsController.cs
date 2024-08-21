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
    public class PasteErrorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PasteErrorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PasteErrors
        public async Task<IActionResult> Index()
        {
            return View(await _context.PasteErrors.ToListAsync());
        }

        // GET: PasteErrors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasteErrors = await _context.PasteErrors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasteErrors == null)
            {
                return NotFound();
            }

            return View(pasteErrors);
        }

        // GET: PasteErrors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PasteErrors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,F1,F2,F3,F4,F5")] PasteErrors pasteErrors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasteErrors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pasteErrors);
        }

        // GET: PasteErrors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasteErrors = await _context.PasteErrors.FindAsync(id);
            if (pasteErrors == null)
            {
                return NotFound();
            }
            return View(pasteErrors);
        }

        // POST: PasteErrors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,F1,F2,F3,F4,F5")] PasteErrors pasteErrors)
        {
            if (id != pasteErrors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasteErrors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasteErrorsExists(pasteErrors.Id))
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
            return View(pasteErrors);
        }

        // GET: PasteErrors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasteErrors = await _context.PasteErrors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasteErrors == null)
            {
                return NotFound();
            }

            return View(pasteErrors);
        }

        // POST: PasteErrors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasteErrors = await _context.PasteErrors.FindAsync(id);
            if (pasteErrors != null)
            {
                _context.PasteErrors.Remove(pasteErrors);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasteErrorsExists(int id)
        {
            return _context.PasteErrors.Any(e => e.Id == id);
        }
    }
}
