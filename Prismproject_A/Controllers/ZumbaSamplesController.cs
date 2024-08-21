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
    public class ZumbaSamplesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZumbaSamplesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZumbaSamples
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZumbaSamples.ToListAsync());
        }

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
                csv.Context.RegisterClassMap<ZumbaSamplesMap>();

                // Read records
                var records = csv.GetRecords<ZumbaSamples>().ToList();

                // Add records to the database context
                _context.ZumbaSamples.AddRange(records);
                await _context.SaveChangesAsync();
            }
        }

        // GET: BoxSubs/ExportToCsv
        public async Task<IActionResult> ExportToCsv()
        {
            var zumbaSamples = await _context.ZumbaSamples.ToListAsync();

            using var writer = new StringWriter();
            using var csv = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));

            csv.WriteRecords(zumbaSamples);
            var csvContent = writer.ToString();
            var fileName = "ZumbaData.csv";

            return File(new System.Text.UTF8Encoding().GetBytes(csvContent), "text/csv", fileName);
        }

        // GET: ZumbaSamples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zumbaSamples = await _context.ZumbaSamples
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zumbaSamples == null)
            {
                return NotFound();
            }

            return View(zumbaSamples);
        }

        // GET: ZumbaSamples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZumbaSamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Barcode,BoxNumber,BoxRow,BoxColumn,dateAdded,Round")] ZumbaSamples zumbaSamples)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zumbaSamples);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zumbaSamples);
        }

        // GET: ZumbaSamples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zumbaSamples = await _context.ZumbaSamples.FindAsync(id);
            if (zumbaSamples == null)
            {
                return NotFound();
            }
            return View(zumbaSamples);
        }

        // POST: ZumbaSamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Barcode,BoxNumber,BoxRow,BoxColumn,dateAdded,Round")] ZumbaSamples zumbaSamples)
        {
            if (id != zumbaSamples.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zumbaSamples);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZumbaSamplesExists(zumbaSamples.Id))
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
            return View(zumbaSamples);
        }

        // GET: ZumbaSamples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zumbaSamples = await _context.ZumbaSamples
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zumbaSamples == null)
            {
                return NotFound();
            }

            return View(zumbaSamples);
        }

        // POST: ZumbaSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zumbaSamples = await _context.ZumbaSamples.FindAsync(id);
            if (zumbaSamples != null)
            {
                _context.ZumbaSamples.Remove(zumbaSamples);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZumbaSamplesExists(int id)
        {
            return _context.ZumbaSamples.Any(e => e.Id == id);
        }
    }
}
