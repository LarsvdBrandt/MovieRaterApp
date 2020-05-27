using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.ViewModels
{
    public class GetWatchListViewModel
    {
        public List<IMovie> Movies { get; set; }
        public List<IWatchList> WatchLists { get; set; }
    }
}
