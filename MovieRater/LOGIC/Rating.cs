using System;
using System.Collections.Generic;
using System.Text;
using LogicInterfaces;
using DataHandlerInterfaces;
using DataHandlerFactory;

namespace Logic
{
    public class Rating : IRating
    {
        private IRatingContext db;
        public int RatingID { get; set; }
        public int MovieID { get; set; }
        public int RatingStars { get; set; }
        public string RatingTitle { get; set; }
        public string RatingComment { get; set; }

        public Rating()
        {
            db = Factory.GetRatingContext();
        }
    }
}
