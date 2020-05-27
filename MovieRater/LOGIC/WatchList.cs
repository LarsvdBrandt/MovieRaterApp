using System;
using System.Collections.Generic;
using System.Text;
using LogicInterfaces;
using DataHandlerInterfaces;
using DataHandlerFactory;

namespace Logic
{
    public class WatchList : IWatchList
    {
        private IWatchListContext db;
        public int MovieID { get; set; }
        public WatchList()
        {
            db = Factory.GetWatchListContext();
        }
    }
}
