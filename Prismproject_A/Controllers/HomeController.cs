using Microsoft.AspNetCore.Mvc;
using Prismproject_A.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Prismproject_A.Data;
using System.Diagnostics;

namespace Prismproject_A.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _logger = logger;
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UploadCsv()
        {
            return View();
        }

    }
}
