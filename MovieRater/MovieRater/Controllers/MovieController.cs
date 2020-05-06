using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRater.Data;
using MovieRater.Models;
using MovieRater.Controllers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MovieRater.Controllers
{
    public class MovieController : Controller
    {
        private MRContext db;
        private readonly IWebHostEnvironment _environment;


        public MovieController(MRContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            this._environment = environment;
        }

        public IActionResult MoviePage(int movieID)
        {
            RatingViewModel ratingViewModel = new RatingViewModel();
            List<MovieViewModel> movieViewModels = db.GetMovieModels().Where(x => x.MovieID == movieID).ToList();
            MovieViewModel currentMovie = movieViewModels[0];

            List<Rating> ratings = db.GetRatingViewModels().Where(x => x.MovieID == movieID).ToList();

            ratingViewModel.MovieViewModel = currentMovie;
            ratingViewModel.Ratings = ratings;
            return View(ratingViewModel);
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

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieViewModel model)
        {
            MovieViewModel realmodel = new MovieViewModel();

            var uploads = Path.Combine(_environment.WebRootPath, "Images/Posters");
            foreach (var file in model.Files)
            {
                realmodel.Poster = file.FileName;
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

            realmodel.MovieID = model.MovieID;
            realmodel.MovieInfo = model.MovieInfo;
            realmodel.MovieSummary = model.MovieSummary;
            realmodel.MovieTitle = model.MovieTitle;
            realmodel.Stars = model.Stars;
            realmodel.Trailer = model.Trailer;
            realmodel.Writers = model.Writers;
            realmodel.Director = model.Director;
            db.AddMovie(realmodel);
            return RedirectToAction("Index", "Home", "");
        }

        public IActionResult RatingPage(int movieID)
        {
            Rating rating = new Rating();
            rating.MovieID = movieID;

            return View(rating);
        }

        [HttpPost]
        public IActionResult AddRating(Rating rating, int movieID)
        {
            List<MovieViewModel> movieModels = db.GetMovieModels().Where(x => x.MovieID == movieID).ToList();
            MovieViewModel currentMovie = movieModels[0];

            if (ModelState.IsValid)
            {
                db.AddRating(rating);
                return RedirectToAction("Index", "Home", "");
            }

            else
                return RedirectToAction("Login", "Account", "");
        }

        [HttpGet]
        public IActionResult EditMoviePage(EditMovieViewModel model, int movieID)
        {
            List<MovieViewModel> movieModels = db.GetMovieModels().Where(x => x.MovieID == movieID).ToList();
            MovieViewModel currentMovie = movieModels[0];
            MovieViewModel realmodel = new MovieViewModel();
            realmodel.MovieID = model.MovieID;
            realmodel.MovieInfo = model.MovieInfo;
            realmodel.MovieSummary = model.MovieSummary;
            realmodel.MovieTitle = model.MovieTitle;
            realmodel.Stars = model.Stars;
            realmodel.Trailer = model.Trailer;
            realmodel.Writers = model.Writers;
            realmodel.Director = model.Director;

            return View(realmodel);
        }

        [HttpPost]
        public async Task<IActionResult> EditMovie(EditMovieViewModel model, int movieID)
        {
            MovieViewModel realmodel = new MovieViewModel();
            if (ModelState.IsValid)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "Images/Posters");
                foreach (var file in model.Files)
                {
                    foreach (var Poster in model.Poster)
                    {
                        realmodel.Poster = file.FileName;
                        if (file.Length > 0)
                        {
                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                    }
                }

                realmodel.MovieID = model.MovieID;
                realmodel.MovieInfo = model.MovieInfo;
                realmodel.MovieSummary = model.MovieSummary;
                realmodel.MovieTitle = model.MovieTitle;
                realmodel.Stars = model.Stars;
                realmodel.Trailer = model.Trailer;
                realmodel.Writers = model.Writers;
                realmodel.Director = model.Director;
                if (model.Poster == null)
                {
                    realmodel.Poster = model.Poster;
                }

                List<MovieViewModel> movieModels = db.GetMovieModels().Where(x => x.MovieID == movieID).ToList();
                MovieViewModel oldMovie = movieModels[0];
                //db.Entry(oldMovie).CurrentValues.SetValue(realmodel);
                return RedirectToAction("MoviePage", new { realmodel.MovieID });
            }
            else
            {
                return View("FailPage");
            }
        }
    }

}