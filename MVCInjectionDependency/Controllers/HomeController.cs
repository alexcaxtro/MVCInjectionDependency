using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCInjectionDependency.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCInjectionDependency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Models.BlogContext _db;

        public HomeController(ILogger<HomeController> logger, Models.BlogContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var lst = _db.Posts.ToList();
            return View(lst);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
