using Logic;
using LogicInterfaces;
using MovieRaterMemoryHandler;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using
using DataHandler.Context;

namespace LogicFactory
{
    public class Factory
    {
        private MemoryTables tables;
        public Factory()
        {
            tables = new MemoryTables();
        }

        public IAccount GetAccount()
        {

            return new Account();
        }

        public IAccountCollection GetAccountCollection()
        {
            return new AccountCollection();
        }

        public IMovie GetMovie()
        {
            return new Movie();
        }

        public IMovieCollection GetMovieCollection(Context context)
        {
            switch (context)
            {
                case Context.Database:
                    return new MovieCollection(new MovieContext());
                case Context.Memory:
                    return new MovieCollection(new MovieMemoryHandler(tables));
                default:
                    return new MovieCollection(new MovieContext());
            }
        }

        public IRating GetRating()
        {
            return new Rating();
        }

        public IRatingCollection GetRatingCollection()
        {
            return new RatingCollection();
        }

        public IWatchList GetWatchListMovie()
        {
            return new WatchList();
        }

        public IWatchListCollection GetWatchListCollection()
        {
            return new WatchListCollection();
        }
    }
}
