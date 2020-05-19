using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandlerInterfaces;
using DataHandlerFactory;
using LogicInterfaces;
using System.Linq;

namespace Logic
{
    public class RatingCollection : IRatingCollection
    {
        private IRatingContext db;
        private List<IRating> ratings;

        public RatingCollection()
        {
            db = Factory.GetRatingContext();
            ratings = new List<IRating>();
            List<IRatingDto> ratingDtos = db.GetRatings();
            foreach (IRatingDto ratingDto in ratingDtos)
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

        public int CreateRating(IRating rating)
        {
            IRatingDto ratingDto = Factory.GetRatingDto();
            ratingDto.RatingID = rating.RatingID;
            ratingDto.MovieID = rating.MovieID;
            ratingDto.RatingStars = rating.RatingStars;
            ratingDto.RatingTitle = rating.RatingTitle;
            ratingDto.RatingComment = rating.RatingComment;

            int rowcount = db.CreateRating(ratingDto);
            return rowcount;
        }

        public List<IRating> GetRatings()
        {
            return ratings;
        }

        public IRating GetRating(int RatingID)
        {
            return ratings.Where(model => model.RatingID == RatingID).FirstOrDefault();
        }

    }
}
