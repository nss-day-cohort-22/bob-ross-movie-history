using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieHistory.Models;
using Microsoft.Extensions.Configuration;
using MovieHistory.Configuration;
using Microsoft.Extensions.Options;

namespace MovieHistory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationConfigurations _appSettings;

        public HomeController(IOptions<ApplicationConfigurations> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            ViewData["apiKey"] = _appSettings.MovieAPIKey;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
