using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demo.UI.Site.Models;
using demo.UI.Site.Repository;

namespace demo.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExportXLS _db;

        public HomeController(IExportXLS db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            var result = _db.Value();
            return View();
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
