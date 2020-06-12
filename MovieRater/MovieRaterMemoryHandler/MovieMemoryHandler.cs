using DataHandler.Context;
using DataHandlerInterfaces;
using MovieRaterMemoryHandler.DataTypes;
using MovieRaterMemoryHandler.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRaterMemoryHandler
{
    public class MovieMemoryHandler : IMovieContext
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private TableMovie table;
        public MovieMemoryHandler(MemoryTables tables)
        {
            this.table = tables.movies;
        }

        public int CreateMovie(IMovieDto movieDto)
        {
            return table.Insert(new DataMovie(movieDto));
        }

        public void DeleteMovie(int movieID)
        {
            throw new NotImplementedException();
        }

        public void EditMovie(string MovieTitle, string MovieInfo, string MovieSummary, string Poster, string Trailer, string Writers, string Stars, string Director, int MovieID)
        {
            throw new NotImplementedException();
        }

        public IMovieDto GetMovie(int movieID)
        {
            throw new NotImplementedException();
        }

        public List<IMovieDto> GetMovies()
        {
            throw new NotImplementedException();
        }
    }
}
