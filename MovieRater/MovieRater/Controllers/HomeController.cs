using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRater.ViewModels;
using LogicFactory;

using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Logic;
using MovieRaterMemoryFactory;
using LogicTypes;

namespace MovieRater.Controllers
{
    public class HomeController : Controller
    {
        private Movie movie;
        private MovieCollection movieCollection;


        public HomeController()
        {
            movieCollection = new Factory().GetMovieCollection(Context.Database);
        }

        public IActionResult Index()
        {
            List<Movie> movies = movieCollection.GetMovies();
            Console.WriteLine("Hallo " + movies.Count);
            MovieIndexViewModel model = new MovieIndexViewModel();

            model.Movies = movies;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new MovieRater.ViewModels.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*private void Test()
        {
            Factory factory = new Factory();
            MovieCollection movieCollection = factory.GetMovieCollection(Context.Memory);

            //Setup
            Movie movie = new Movie()
            {
                MovieTitle = "Casper",
                MovieInfo = "MovieInfo",
                MovieSummary = "info",
                Poster = "poster",
                Trailer = "trailer",
                Writers = "writers",
                Stars = "stars",
                Director = "director"
            };
            movieCollection.CreateMovie(movie);

            //Action
            movieCollection.DeleteMovie(movie);

            //Assert
            Console.WriteLine(movieCollection.GetMovies().Where(m => m.MovieID == movie.MovieID).ToList().Count);
        }*/
    }
}
