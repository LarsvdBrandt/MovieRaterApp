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

        public AccountCollection GetAccountCollection(Context context)
        {
            switch (context)
            {
                case Context.Database:
                    return new AccountCollection(new AccountContext());
                case Context.Memory:
                    return new AccountCollection(new AccountMemoryHandler(tables));
                default:
                    return new AccountCollection(new AccountContext());
            }
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

        public RatingCollection GetRatingCollection(Context context)
        {
            switch (context)
            {
                case Context.Database:
                    return new RatingCollection(new RatingContext());
                case Context.Memory:
                    return new RatingCollection(new RatingMemoryHandler(tables));
                default:
                    return new RatingCollection(new RatingContext());
            }
        }

        public WatchListCollection GetWatchListCollection()
        {
            return new WatchListCollection();
        }
    }
}
