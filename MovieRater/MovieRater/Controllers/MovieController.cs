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
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Logic;
using LogicTypes;

namespace MovieRater.Controllers
{
    public class MovieController : Controller
    {
        private IWebHostEnvironment _environment;
        private readonly long _fileSizeLimit;
        private string[] permittedExtensions = { ".png", ".jpg", ".jpeg" };

        private Movie movie;
        private MovieCollection movieCollection;
        private Rating rating;
        private RatingCollection ratingCollection;
        private WatchList watchList;
        private WatchListCollection watchListCollection;


        public MovieController(IWebHostEnvironment environment)
        {
            this._environment = environment;

            movieCollection = new Factory().GetMovieCollection(Context.Database);

            ratingCollection = new Factory().GetRatingCollection(Context.Database);

            watchListCollection = new Factory().GetWatchListCollection();
        }

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
                Writers = movie.Writers,

            };

            List<Rating> ratings = ratingCollection.GetRatingsMovie(MovieID);
            model.Ratings = ratings;

            return View(model);
        }

        [HttpGet]
        public IActionResult EditMoviePage(int MovieID)
        {

            movie = movieCollection.GetMovie(MovieID);
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
        public async Task<IActionResult> EditMovie(EditMovieViewModel model)
        {
            movie = new Movie();

            if (model.Files != null)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "Images/Posters");
                foreach (var file in model.Files)
                {
                    movie.Poster = file.FileName;
                    if (file.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                }

                movie.MovieID = model.MovieID;
                movie.MovieInfo = model.MovieInfo;
                movie.MovieSummary = model.MovieSummary;
                movie.MovieTitle = model.MovieTitle;
                movie.Stars = model.Stars;
                movie.Trailer = model.Trailer;
                movie.Writers = model.Writers;
                movie.Director = model.Director;

                movieCollection.EditMovie(movie);
            }
            else
            {
                movie.MovieID = model.MovieID;
                movie.MovieInfo = model.MovieInfo;
                movie.MovieSummary = model.MovieSummary;
                movie.Poster = model.Poster;
                movie.MovieTitle = model.MovieTitle;
                movie.Stars = model.Stars;
                movie.Trailer = model.Trailer;
                movie.Writers = model.Writers;
                movie.Director = model.Director;

                movieCollection.EditMovie(movie);
            }

            
            return RedirectToAction("EditsuccessPage");
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieViewModel model)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "Images/Posters");
            foreach (var file in model.Files)
            {
                movie.Poster = file.FileName;
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

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

            movieCollection.DeleteMovie(movie);

            return RedirectToAction("EditSuccessPage");
        }

        [HttpGet]
        public IActionResult AddRatingPage(int movieID)
        {
            movie = movieCollection.GetMovie(movieID);

            AddRatingViewModel model = new AddRatingViewModel()
            {
                MovieID = movie.MovieID
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddRating(AddRatingViewModel model)
        {
            rating = new Rating();
            rating.RatingTitle = model.RatingTitle;
            rating.RatingStars = model.RatingStars;
            rating.RatingID = model.RatingID;
            rating.RatingComment = model.RatingComment;
            rating.MovieID = model.MovieID;

            int rowcount = ratingCollection.CreateRating(rating);

            if (rowcount == 1)
                return RedirectToAction("EditSuccessPage");
            else
                return RedirectToAction("FailPage");
        }

        [HttpPost]
        public IActionResult AddWatchList(AddRatingViewModel model)
        {
            watchList = new WatchList();
            watchList.MovieID = model.MovieID;

            int rowcount = watchListCollection.CreateWatchList(watchList);

            if (rowcount == 1)
                return RedirectToAction("EditSuccessPage");
            else
                return RedirectToAction("FailPage");
        }
        [HttpGet]
        public IActionResult AddWatchListPage(int movieID)
        {
            movie = movieCollection.GetMovie(movieID);

            AddRatingViewModel model = new AddRatingViewModel()
            {
                MovieID = movie.MovieID
            };

            return View(model);
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
        public IActionResult EditSuccessPage()
        {

            return View();
        }

    }

}