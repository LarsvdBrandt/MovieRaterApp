using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IWatchList
    {
        public int WatchListID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
    }
}
