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
    public class WatchListController : Controller
    {
        private WatchList watchList;
        private WatchListCollection watchListCollection;

        private Movie movie;
        private MovieCollection movieCollection;

        public WatchListController()
        {
            watchListCollection = new Factory().GetWatchListCollection();

            movieCollection = new Factory().GetMovieCollection(Context.Database);
        }
        [HttpGet]
        public IActionResult WatchListPage()
        {
            List<WatchList> watchLists = watchListCollection.GetWatchListMovie();
            GetWatchListViewModel model = new GetWatchListViewModel();

            model.WatchLists = watchLists;

            return View(model);

        }


    }
}