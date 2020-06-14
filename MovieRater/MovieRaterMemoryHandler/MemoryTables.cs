using MovieRaterMemoryHandler.DataTypes;
using MovieRaterMemoryHandler.Tables;
using System;

namespace MovieRaterMemoryHandler
{
    public class MemoryTables
    {
        public TableMovie movies { get; set; } = new TableMovie();

        public MemoryTables()
        {
            CreateMovie();
        }

        //Zet default film in de table
        private void CreateMovie()
        {
            movies.Insert(new DataMovie()
            {
                MovieTitle = "Casper",
                MovieInfo = "MovieInfo",
                MovieSummary = "info",
                Poster = "poster",
                Trailer = "trailer",
                Writers = "writers",
                Stars = "stars",
                Director = "director"
            });
        }
    }
}
