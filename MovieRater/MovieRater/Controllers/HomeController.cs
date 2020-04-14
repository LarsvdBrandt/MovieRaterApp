using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRater.Models;
using MovieRater.Data;

namespace MovieRater.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MRContext db;

        public HomeController(ILogger<HomeController> logger, MRContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            List<MovieViewModel> movieModels = db.GetMovieModels();
            return View(movieModels);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
