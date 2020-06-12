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
        public static IAccountContext GetAccountContext()
        {
            return new AccountContext();
        }

        public static IAccountDto GetAccountDto()
        {
            return new AccountDto();
        }

        public static IMovieContext GetMovieContext()
        {
            return new MovieContext();
        }

        public static IMovieDto GetMovieDto()
        {
            return new MovieDto();
        }
        
        public static IRatingContext GetRatingContext()
        {
            return new RatingContext();
        }

        public static IRatingDto GetRatingDto()
        {
            return new RatingDto();
        }

        public static IWatchListContext GetWatchListContext()
        {
            return new WatchListContext();
        }

        public static IWatchListDto GetWatchListDto()
        {
            return new WatchListDto();
        }

    }
}
