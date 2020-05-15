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
    public class WatchListController : Controller
    {
        private MRContext db;
        private readonly IWebHostEnvironment _environment;


        public WatchListController(MRContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            this._environment = environment;
        }

        //public IActionResult WatchListPage(int movieID)
        //{
            //MovieViewModel movieViewModel = new MovieViewModel();
            //MovieViewModel.MovieID = movieID;

            //return View(movieViewModel);


            //WatchList watchList = new WatchList();
            //watchList.MovieID = movieID;

            //return View(watchList);
        //}


    }
}