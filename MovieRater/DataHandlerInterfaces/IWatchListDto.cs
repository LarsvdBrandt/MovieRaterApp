using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandlerInterfaces
{
    public interface IWatchListDto
    {
        public int WatchListID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
    }
}
