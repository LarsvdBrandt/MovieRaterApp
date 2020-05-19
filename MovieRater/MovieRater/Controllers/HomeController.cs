/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRater.Models;
using LogicFactory;
using LogicInterfaces;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using MovieRater.ViewModels;

namespace MovieRater.Controllers
{
    public class HomeController : Controller
    {
        private IMovie movie;
        private IMovieCollection movieCollection;


        public HomeController()
        {
            movie = Factory.GetMovie();
            movieCollection = Factory.GetMovieCollection();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<IMovie> movies = movieCollection.GetMovies();
            MovieIndexViewModel model = new MovieIndexViewModel();

            model.Movies = movies;

            return View(model);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}*/
