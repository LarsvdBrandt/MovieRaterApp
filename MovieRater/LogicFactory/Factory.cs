using Logic;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicFactory
{
    public static class Factory
    {
        public static IAccount GetAccount()
        {
            return new Account();
        }

        public static IAccountCollection GetAccountCollection()
        {
            return new AccountCollection();
        }

        public static IMovie GetMovie()
        {
            return new Movie();
        }

        public static IMovieCollection GetMovieCollection()
        {
            return new MovieCollection();
        }

        public static IRating GetRating()
        {
            return new Rating();
        }

        public static IRatingCollection GetRatingCollection()
        {
            return new RatingCollection();
        }

        public static IWatchList GetWatchListMovie()
        {
            return new WatchList();
        }

        public static IWatchListCollection GetWatchListCollection()
        {
            return new WatchListCollection();
        }
    }
}
