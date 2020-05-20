using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRater.Models;
using MovieRater.ViewModels;
using MovieRater.Controllers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using LogicFactory;
using LogicInterfaces;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace MovieRater.Controllers
{
    public class MovieController : Controller
    {
        private IMovie movie;
        private IMovieCollection movieCollection;

        [HttpGet]
        public IActionResult MoviePage(int MovieID)
        {
            movie = movieCollection.GetMovie(MovieID);

            MovieRatingViewModel model = new MovieRatingViewModel()
            {
                MovieID = movie.MovieID,
                MovieTitle = movie.MovieTitle,
                MovieInfo = movie.MovieInfo,
                MovieSummary = movie.MovieSummary,
                Poster = movie.Poster,
                Director = movie.Director,
                Stars = movie.Stars,
                Trailer = movie.Trailer,
                Writers = movie.Writers
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult EditMoviePage(int movieID)
        {
            EditMovieViewModel model = new EditMovieViewModel()
            {
                MovieID = movie.MovieID,
                MovieTitle = movie.MovieTitle,
                MovieInfo = movie.MovieInfo,
                MovieSummary = movie.MovieSummary,
                Poster = movie.Poster,
                Director = movie.Director,
                Stars = movie.Stars,
                Trailer = movie.Trailer,
                Writers = movie.Writers
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditMovie(EditMovieViewModel model)
        {
            movie.MovieID = model.MovieID;
            movie.MovieInfo = model.MovieInfo;
            movie.MovieSummary = model.MovieSummary;
            movie.MovieTitle = model.MovieTitle;
            movie.Stars = model.Stars;
            movie.Trailer = model.Trailer;
            movie.Writers = model.Writers;
            movie.Director = model.Director;

            movie.EditMovie();
            return RedirectToAction("EditsuccessPage");
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovieViewModel model)
        {
            movie.MovieID = model.MovieID;
            movie.MovieInfo = model.MovieInfo;
            movie.MovieSummary = model.MovieSummary;
            movie.MovieTitle = model.MovieTitle;
            movie.Stars = model.Stars;
            movie.Trailer = model.Trailer;
            movie.Writers = model.Writers;
            movie.Director = model.Director;

            int rowcount = movieCollection.CreateMovie(movie);

            if (rowcount == 1)
                return RedirectToAction("EditSuccessPage");
            else
                return RedirectToAction("FailPage");
        }

        [HttpGet]
        public IActionResult DeleteMoviePage(int movieID)
        {
            movie = movieCollection.GetMovie(movieID);

            DeleteMovieViewModel model = new DeleteMovieViewModel()
            {
                MovieID = movie.MovieID,
                MovieTitle = movie.MovieTitle,
                MovieInfo = movie.MovieInfo,
                MovieSummary = movie.MovieSummary,
                Poster = movie.Poster,
                Director = movie.Director,
                Stars = movie.Stars,
                Trailer = movie.Trailer,
                Writers = movie.Writers
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteMovie(int movieID)
        {
            movie = movieCollection.GetMovie(movieID);

            movie.DeleteMovie();

            return RedirectToAction("EditSuccessPage");
        }

        [HttpGet]
        public IActionResult AddMoviePage()
        {

            return View();
        }

        public IActionResult FailPage()
        {

            return View();
        }

    }

}