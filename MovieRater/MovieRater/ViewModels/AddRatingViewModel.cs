using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.ViewModels
{
    public class AddRatingViewModel
    {
        public int RatingID { get; set; }
        public int MovieID { get; set; }
        public int RatingStars { get; set; }
        public string RatingTitle { get; set; }
        public string RatingComment { get; set; }
    }
}
