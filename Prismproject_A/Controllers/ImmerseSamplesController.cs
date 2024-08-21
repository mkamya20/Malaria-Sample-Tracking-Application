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
    public class ImmerseSamplesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImmerseSamplesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ImmerseSamples
        public async Task<IActionResult> Index()
        {
            return View(await _context.ImmerseSamples.ToListAsync());
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
                csv.Context.RegisterClassMap<ImmerseSamplesMap>();

                // Read records
                var records = csv.GetRecords<ImmerseSamples>().ToList();

                // Add records to the database context
                _context.ImmerseSamples.AddRange(records);
                await _context.SaveChangesAsync();
            }
        }

        // GET: ImmerseSamples/ExportToCsv
        public async Task<IActionResult> ExportToCsv()
        {
            var immersesamples = await _context.ImmerseSamples.ToListAsync();

            using var writer = new StringWriter();
            using var csv = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));

            csv.WriteRecords(immersesamples);
            var csvContent = writer.ToString();
            var fileName = "ImmerseSamples.csv";

            return File(new System.Text.UTF8Encoding().GetBytes(csvContent), "text/csv", fileName);
        }

        // GET: ImmerseSamples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var immerseSamples = await _context.ImmerseSamples
                .FirstOrDefaultAsync(m => m.Id == id);
            if (immerseSamples == null)
            {
                return NotFound();
            }

            return View(immerseSamples);
        }

        // GET: ImmerseSamples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImmerseSamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoxNumber,Barcode,BoxRow,BoxColumn,TbldateAdded,PlateNumber,PcrplateLayout,AliquotePlateNumber,AliquotePlatePosition")] ImmerseSamples immerseSamples)
        {
            if (ModelState.IsValid)
            {
                _context.Add(immerseSamples);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(immerseSamples);
        }

        // GET: ImmerseSamples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var immerseSamples = await _context.ImmerseSamples.FindAsync(id);
            if (immerseSamples == null)
            {
                return NotFound();
            }
            return View(immerseSamples);
        }

        // POST: ImmerseSamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoxNumber,Barcode,BoxRow,BoxColumn,TbldateAdded,PlateNumber,PcrplateLayout,AliquotePlateNumber,AliquotePlatePosition")] ImmerseSamples immerseSamples)
        {
            if (id != immerseSamples.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(immerseSamples);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImmerseSamplesExists(immerseSamples.Id))
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
            return View(immerseSamples);
        }

        // GET: ImmerseSamples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var immerseSamples = await _context.ImmerseSamples
                .FirstOrDefaultAsync(m => m.Id == id);
            if (immerseSamples == null)
            {
                return NotFound();
            }

            return View(immerseSamples);
        }

        // POST: ImmerseSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var immerseSamples = await _context.ImmerseSamples.FindAsync(id);
            if (immerseSamples != null)
            {
                _context.ImmerseSamples.Remove(immerseSamples);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImmerseSamplesExists(int id)
        {
            return _context.ImmerseSamples.Any(e => e.Id == id);
        }
    }
}
