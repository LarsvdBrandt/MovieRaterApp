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
            List<MovieViewModel> movieModels = db.GetMovieModels().Where(x => x.MovieID == movieID).ToList();
            return View(movieModels[0]);
        }


        [HttpGet]
        public IActionResult AddMovie()
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

    }
}