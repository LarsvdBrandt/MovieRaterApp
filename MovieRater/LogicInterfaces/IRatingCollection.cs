using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IRatingCollection
    {
        List<IRating> GetRatings();
        List<IRating> GetRatingsMovie(int MovieID);
        IRating GetRating(int RatingID);
        int CreateRating(IRating rating);
    }
}
