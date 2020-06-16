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

        //Maak movieHandler aan en geeft door dat die memoryhandler gebruikt en geef aan memoryhandler 
        //door dat hij line 9(memory table) gebruikt - object

        //ga naar movieCollection
        public MovieCollection CreateMovieCollection()
        {
            return new MovieCollection(new MovieMemoryHandler(tables));
        }

    }
}
