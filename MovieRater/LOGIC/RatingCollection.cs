using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandlerInterfaces;


using System.Linq;
using MovieRaterDtos;
using DataHandler;

namespace Logic
{
    public class RatingCollection
    {
        private IRatingContext db;
        private List<Rating> ratings;

        public RatingCollection()
        {
            db = new RatingContext();
            ratings = new List<Rating>();
            List<RatingDto> ratingDtos = db.GetRatings();
            foreach (RatingDto ratingDto in ratingDtos)
            {
                ratings.Add(new Rating()
                {
                    RatingID = ratingDto.RatingID,
                    MovieID = ratingDto.MovieID,
                    RatingStars = ratingDto.RatingStars,
                    RatingTitle = ratingDto.RatingTitle,
                    RatingComment = ratingDto.RatingComment
                });
            }
        }

        public int CreateRating(Rating rating)
        {
            RatingDto ratingDto = new RatingDto();
            ratingDto.RatingID = rating.RatingID;
            ratingDto.MovieID = rating.MovieID;
            ratingDto.RatingStars = rating.RatingStars;
            ratingDto.RatingTitle = rating.RatingTitle;
            ratingDto.RatingComment = rating.RatingComment;

            int rowcount = db.CreateRating(ratingDto);
            return rowcount;
        }

        public List<Rating> GetRatings()
        {
            return ratings;
        }        
        
        public List<Rating> GetRatingsMovie(int movieID)
        {
            return ratings.Where(model => model.MovieID == movieID).ToList();
        }

        public Rating GetRating(int movieID)
        {
            return ratings.Where(model => model.MovieID == movieID).FirstOrDefault();
        }

    }
}
