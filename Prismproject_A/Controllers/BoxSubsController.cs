using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prismproject_A.Data;
using Prismproject_A.Models;
using CsvHelper;
using System.Globalization;

namespace Prismproject_A.Controllers
{
    public class BoxSubsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoxSubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BoxSubs
        public async Task<IActionResult> Index()
        {
            return View(await _context.BoxSubs.ToListAsync());
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> UploadCsv(IFormFile csvFile)
        {
            if (csvFile != null && csvFile.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await csvFile.CopyToAsync(stream);
                    stream.Position = 0; // Reset stream position to the beginning
                    await ImportCsvAsync(stream);
                }
                return RedirectToAction("Index"); // Redirect to a suitable action after successful upload
            }

            // Handle file not selected case
            ModelState.AddModelError("", "Please select a CSV file.");
            return View("Index"); // Return to the view with the form
        }

        private async Task ImportCsvAsync(Stream fileStream)
        {
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                // Register the class map
                csv.Context.RegisterClassMap<BoxSubsMap>();

                // Read records
                var records = csv.GetRecords<BoxSubs>().ToList();

                // Add records to the database context
                _context.BoxSubs.AddRange(records);
                await _context.SaveChangesAsync();
            }
        }

        // GET: BoxSubs/ExportToCsv
        public async Task<IActionResult> ExportToCsv()
        {
            var boxSubs = await _context.BoxSubs.ToListAsync();

            using var writer = new StringWriter();
            using var csv = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));

            csv.WriteRecords(boxSubs);
            var csvContent = writer.ToString();
            var fileName = "BoxSubsData.csv";

            return File(new System.Text.UTF8Encoding().GetBytes(csvContent), "text/csv", fileName);
        }


        // GET: BoxSubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxSubs = await _context.BoxSubs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boxSubs == null)
            {
                return NotFound();
            }

            return View(boxSubs);
        }

        // GET: BoxSubs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoxSubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoxNumber,Barcode,BoxRow,BoxColumn,TbldateAdded,PlateNumber,PcrplateLayout,AliquotePlateNumber,AliquotePlatePosition")] BoxSubs boxSubs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boxSubs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boxSubs);
        }

        // GET: BoxSubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxSubs = await _context.BoxSubs.FindAsync(id);
            if (boxSubs == null)
            {
                return NotFound();
            }
            return View(boxSubs);
        }

        // POST: BoxSubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoxNumber,Barcode,BoxRow,BoxColumn,TbldateAdded,PlateNumber,PcrplateLayout,AliquotePlateNumber,AliquotePlatePosition")] BoxSubs boxSubs)
        {
            if (id != boxSubs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boxSubs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoxSubsExists(boxSubs.Id))
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
            return View(boxSubs);
        }

        // GET: BoxSubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boxSubs = await _context.BoxSubs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boxSubs == null)
            {
                return NotFound();
            }

            return View(boxSubs);
        }

        // POST: BoxSubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boxSubs = await _context.BoxSubs.FindAsync(id);
            if (boxSubs != null)
            {
                _context.BoxSubs.Remove(boxSubs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoxSubsExists(int id)
        {
            return _context.BoxSubs.Any(e => e.Id == id);
        }
    }


   
}
