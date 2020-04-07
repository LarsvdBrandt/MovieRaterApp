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

            /*
            MovieModel homeImage = new MovieModel()
            {
                MovieId = 1,
                Poster = "/Images/1917.jpg",
                Title = "1917"

                //ImageHoofd = new List<string>() { "/Images/1917.jpg", "/Images/BadBoysForLife.jpg", "/Images/MySpy.jpg", "/Images/BloodShot.jpg" },
                //TitleHoofd = new List<string>() { "Bad Boys For Life", "1917", "My Spy", "Bloodshot", "Suriname", "Sonic", "The Boy", "Queen & Slim"}
            };            
            
            MovieModel homeImage2 = new MovieModel()
            {
                MovieId = 2,
                Poster = "/Images/BadBoysForLife.jpg",
                Title = "BadBoysForLife"
            };

            MovieModel homeImage3 = new MovieModel()
            {
                MovieId = 3,
                Poster = "/Images/MySpy.jpg",
                Title = "MySpy"
            };

            MovieModel homeImage4 = new MovieModel()
            {
                MovieId = 4,
                Poster = "/Images/BloodShot.jpg",
                Title = "BloodShot"
            };
            List<MovieModel> MovieModels = new List<MovieModel>() { homeImage, homeImage2, homeImage3, homeImage4 };

            return View(MovieModels);
            */

            List<MovieModel> movieModels = db.GetMovieModels();
            return View(movieModels);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
