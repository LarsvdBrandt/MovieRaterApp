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
            watchList = new Factory().GetWatchListMovie();
            watchListCollection = new Factory().GetWatchListCollection();

            movie = new Factory().GetMovie();
            movieCollection = new Factory().GetMovieCollection(Context.Database);
        }
        [HttpGet]
        public IActionResult WatchListPage()
        {
            List<IWatchList> watchLists = watchListCollection.GetWatchListMovie();
            GetWatchListViewModel model = new GetWatchListViewModel();

            model.WatchLists = watchLists;

            return View(model);

        }


    }
}