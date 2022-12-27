using information.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics;
using System.Net.Cache;

namespace information.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Store sto = new Store
            {
                Id = 1 ,
                Name = "Moath",
                FamilyName = "Al-Bakri",
                Address = "ABHA",
                CountryOfOrigin = "Saudi Arabia",
                EMailAdress = "m@nupco.com",
                Age = 24,
                Hired= true
            };
            ViewData["Message"] = sto;
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