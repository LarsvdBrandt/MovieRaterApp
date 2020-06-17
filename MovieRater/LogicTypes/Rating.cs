using MovieRaterDtos;
using System;
using System.Collections.Generic;
using System.Text;


namespace LogicTypes
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int MovieID { get; set; }
        public int RatingStars { get; set; }
        public string RatingTitle { get; set; }
        public string RatingComment { get; set; }

        public Rating()
        {

        }

        public Rating(RatingDto rating)
        {
            this.RatingID = rating.RatingID;
            this.MovieID = rating.MovieID;
            this.RatingStars = rating.RatingStars;
            this.RatingTitle = rating.RatingTitle;
            this.RatingComment = rating.RatingComment;
        }

    }
}
