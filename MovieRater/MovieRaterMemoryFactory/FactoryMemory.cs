using Logic;
using MovieRaterMemoryHandler;
using System;

namespace MovieRaterMemoryFactory
{
    public class FactoryMemory
    {
        private static MemoryTables tables;

        public FactoryMemory()
        {
            tables = new MemoryTables();
        }

        public MovieCollection CreateMovieCollection()
        {
            return new MovieCollection(new MovieMemoryHandler(tables));
        }
    }
}
