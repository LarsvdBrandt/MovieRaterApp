using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Context;
using DataHandler.Models;
using DataHandlerInterfaces;

namespace DataHandlerFactory
{
    public static class Factory
    {
        public static IMovieContext GetMovieContext()
        {
            return new MovieContext();
        }

        public static IRatingContext GetRating()
        {
            return new RatingContext();
        }



    }
}
