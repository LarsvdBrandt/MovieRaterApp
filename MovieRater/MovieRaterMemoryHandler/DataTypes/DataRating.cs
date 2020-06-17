using Microsoft.AspNetCore.Http;
using MovieRaterDtos;
using System.Collections.Generic;

namespace MovieRaterMemoryHandler.DataTypes
{
    public class DataRating
    {
        public int RatingID { get; set; }
        public int MovieID { get; set; }
        public int RatingStars { get; set; }
        public string RatingTitle { get; set; }
        public string RatingComment { get; set; }

        //Zodat als er een dto wordt meegegeven er een datatable van wordt gemaakt.
        public DataRating(RatingDto ratingDto)
        {
            MovieID = ratingDto.MovieID;
            RatingStars = ratingDto.RatingStars;
            RatingTitle = ratingDto.RatingTitle;
            RatingComment = ratingDto.RatingComment;
        }

        //Zodat ook een lege object kan aanmaken zonder dto mee te geven
        public DataRating()
        {

        }

        //zet data in ToDto voor door te sturen naar de testcase
        public RatingDto ToDto()
        {
            RatingDto rating = new RatingDto();
            rating.MovieID = this.MovieID;
            rating.RatingID = this.RatingID;
            rating.RatingStars = this.RatingStars;
            rating.RatingTitle = this.RatingTitle;
            rating.RatingComment = this.RatingComment;

            return rating;
        }
    }
}
