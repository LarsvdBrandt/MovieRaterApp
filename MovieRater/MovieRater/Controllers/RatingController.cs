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

namespace MovieRater.Controllers
{
    public class RatingController : Controller
    {
        private Rating rating;
        private RatingCollection ratingCollection;

        [HttpGet]
        public IActionResult GetRating(int movieID)
        {
            rating = ratingCollection.GetRating(movieID);

            RatingViewModel model = new RatingViewModel()
            {
                MovieID = rating.MovieID,
                RatingID = rating.RatingID,
                RatingComment = rating.RatingComment,
                RatingStars = rating.RatingStars,
                RatingTitle = rating.RatingTitle
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
    }
}