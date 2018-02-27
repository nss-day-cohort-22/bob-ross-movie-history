    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieHistory.Models;
using Microsoft.Extensions.Configuration;
using MovieHistory.Services;
using Microsoft.Extensions.Options;
using MovieHistory.Data;

namespace MovieHistory.Controllers
{
    public class MovieController : Controller
    {
        private readonly IApplicationConfiguration _appSettings;
        private ApplicationDbContext _context;

        public MovieController(IApplicationConfiguration appSettings, ApplicationDbContext ctx)
        {
            _appSettings = appSettings;
            _context = ctx;
        }

        public async Task<IActionResult> Track(string apiId, string title, string img)
        {
            var movie = new Movie
            {
                ApiId = Int32.Parse(apiId),
                Title = title,
                ImgUrl = img
            };

            _context.Add(movie);
            await _context.SaveChangesAsync();

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
