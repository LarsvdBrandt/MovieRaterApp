using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IRatingCollection
    {
        List<IRating> GetRatings();
        IRating GetRating(int RatingID);
        int CreateRating(IRating rating);
    }
}
