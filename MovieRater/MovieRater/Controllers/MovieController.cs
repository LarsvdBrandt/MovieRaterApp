﻿using System;
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
        private IWebHostEnvironment _environment;
        private readonly long _fileSizeLimit;
        private string[] permittedExtensions = { ".png", ".jpg", ".jpeg" };

        private IMovie movie;
        private IMovieCollection movieCollection;
        private IRating rating;
        private IRatingCollection ratingCollection;
        private IWatchList watchList;
        private IWatchListCollection watchListCollection;


        public MovieController(IWebHostEnvironment environment)
        {

            this._environment = environment;

            movie = Factory.GetMovie();
            movieCollection = Factory.GetMovieCollection();

            rating = Factory.GetRating();
            ratingCollection = Factory.GetRatingCollection();
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

            List<IRating> ratings = ratingCollection.GetRatingsMovie(MovieID);
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

        /*
        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieViewModel model)
        {
            AddMovieViewModel movie = new AddMovieViewModel();
            if (ModelState.IsValid)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "Images/Posters");
                foreach (var file in model.Files)
                {
                    var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                    if (file.Length > 0 && file.Length < _fileSizeLimit && permittedExtensions.Contains(ext))
                    {
                        movie.Poster = file.FileName;
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                    else
                    {
                        return View("FailPage");
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
        }*/

        
        [HttpPost]
        public IActionResult AddMovie(AddMovieViewModel model)
        {
            movie.MovieID = model.MovieID;
            movie.Poster = model.Poster;
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
        public IActionResult AddWatchList(MovieRatingViewModel model)
        {
            watchList.MovieID = model.MovieID;

            int rowcount = watchListCollection.AddWatchList(watchList);

            if (rowcount == 1)
                return RedirectToAction("EditSuccessPage");
            else
                return RedirectToAction("FailPage");
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