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
    public class BoxMainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoxMainController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BoxMain
        public async Task<IActionResult> Index()
        {
            return View(await _context.BoxMain.ToListAsync());
        }

        // GET: BoxMain/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxMain = await _context.BoxMain
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boxMain == null)
            {
                return NotFound();
            }

            return View(boxMain);
        }

        // GET: BoxMain/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoxMain/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoxNumber,SampleType,Boxlocation,F4,F5")] BoxMain boxMain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boxMain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boxMain);
        }

        // GET: BoxMain/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxMain = await _context.BoxMain.FindAsync(id);
            if (boxMain == null)
            {
                return NotFound();
            }
            return View(boxMain);
        }

        // POST: BoxMain/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoxNumber,SampleType,Boxlocation,F4,F5")] BoxMain boxMain)
        {
            if (id != boxMain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boxMain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoxMainExists(boxMain.Id))
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
            return View(boxMain);
        }

        // GET: BoxMain/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxMain = await _context.BoxMain
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boxMain == null)
            {
                return NotFound();
            }

            return View(boxMain);
        }

        // POST: BoxMain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boxMain = await _context.BoxMain.FindAsync(id);
            if (boxMain != null)
            {
                _context.BoxMain.Remove(boxMain);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoxMainExists(int id)
        {
            return _context.BoxMain.Any(e => e.Id == id);
        }
    }
}
