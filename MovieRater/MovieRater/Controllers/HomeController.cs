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
            Test();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new MovieRater.ViewModels.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void Test()
        {
            Factory factory = new Factory();
            MovieCollection movieCollection = factory.GetMovieCollection(Context.Memory);

            Movie insertMovie = new Movie()
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

            bool found = false;

            //Action
            movieCollection.CreateMovie(insertMovie);

            //Assert
            foreach (Movie movie in movieCollection.GetMovies())
            {
                if (movie.MovieTitle.Equals("Casper"))
                {
                    found = true;
                }
            }
            Console.WriteLine(found);

        }
    }
}
