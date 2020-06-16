using DataHandler;
using Logic;
using MovieRaterMemoryHandler;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace LogicFactory
{
    public class Factory
    {
        private MemoryTables tables;
        public Factory()
        {
            tables = new MemoryTables();
        }

        public AccountCollection GetAccountCollection()
        {
            return new AccountCollection();
        }

        public MovieCollection GetMovieCollection(Context context)
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

        public RatingCollection GetRatingCollection()
        {
            return new RatingCollection();
        }

        public WatchListCollection GetWatchListCollection()
        {
            return new WatchListCollection();
        }
    }
}
