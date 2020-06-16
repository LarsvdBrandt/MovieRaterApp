using MovieRaterDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandlerInterfaces
{
    public interface IRatingContext
    {
        string ConnectionString { get; set; }
        int CreateRating(RatingDto ratingDto);
        List<RatingDto> GetRatings();
        List<RatingDto> GetRatingsMovie(int MovieID);
    }
}
