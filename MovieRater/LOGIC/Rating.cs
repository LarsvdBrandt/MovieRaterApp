using System;
using System.Collections.Generic;
using System.Text;

using DataHandlerInterfaces;


namespace Logic
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int MovieID { get; set; }
        public int RatingStars { get; set; }
        public string RatingTitle { get; set; }
        public string RatingComment { get; set; }
    }
}
