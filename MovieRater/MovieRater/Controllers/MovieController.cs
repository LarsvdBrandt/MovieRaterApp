using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRater.Data;
using MovieRater.Models;
using MovieRater.Controllers;

namespace MovieRater.Controllers
{
    public class MovieController : Controller
    {
        private MRContext db;

        public MovieController(MRContext db)
        {
            this.db = db;
        }

        public IActionResult MoviePage(int movieID)
        {
            List<MovieViewModel> movieModels = db.GetMovieModels().Where(x => x.MovieID == movieID).ToList();
            return View(movieModels[0]);
        }

        public IActionResult AddMovie()
        {
            return View();
        }
    }
}