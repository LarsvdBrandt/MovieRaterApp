using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

namespace DataHandlerInterfaces
{
    public interface IRatingContext
    {
        string ConnectionString { get; set; }

        int CreateRating(IRatingDto ratingDto);
        IMovieDto GetRating(int ratingID);
        List<IRatingDto> GetRatings();
    }
}
