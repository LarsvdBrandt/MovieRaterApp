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
    public class WatchListController : Controller
    {
        private IWatchList watchList;
        private IWatchListCollection watchListCollection;

        private IMovie movie;
        private IMovieCollection movieCollection;

        public WatchListController()
        {
            watchList = Factory.GetWatchList();
            watchListCollection = Factory.GetWatchListCollection();

            movie = Factory.GetMovie();
            movieCollection = Factory.GetMovieCollection();
        }
        [HttpGet]
        public IActionResult WatchListPage()
        {
            List<IMovie> movies = movieCollection.GetMovies();
            List<IWatchList> watchLists = watchListCollection.GetWatchList();
            GetWatchListViewModel model = new GetWatchListViewModel();

            model.Movies = movies;
            model.WatchLists = watchLists;

            return View(model);
        }


    }
}