using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataHandlerInterfaces;

namespace MovieRater.Models
{
    public class WatchListDto : IWatchListDto
    {
        public int WatchListID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
    }
}
