using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class WatchList
    {
        public int WatchListID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
    }
}
