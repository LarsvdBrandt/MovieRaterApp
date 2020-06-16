using DataHandlerInterfaces;
using MovieRaterDtos;
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
        private TableMovie movieTable;

        //Data van tabel ophalen
        public MovieMemoryHandler(MemoryTables tables)
        {
            this.movieTable = tables.movies;
        }

        //In de tabel data van movieDto zetten
        public int CreateMovie(MovieDto movieDto)
        {
            return movieTable.Insert(new DataMovie(movieDto));
        }

        public void DeleteMovie(int movieID)
        {
            throw new NotImplementedException();
        }

        public void EditMovie(string MovieTitle, string MovieInfo, string MovieSummary, string Poster, string Trailer, string Writers, string Stars, string Director, int MovieID)
        {
            throw new NotImplementedException();
        }

        public MovieDto GetMovie(int movieID)
        {
            throw new NotImplementedException();
        }

        //door de lijst van memorytable loopen om zo alle films in een lijst te zetten.
        public List<MovieDto> GetMovies()
        {
            List<MovieDto> movieDtos = new List<MovieDto>();
            foreach(DataMovie movie in movieTable.Movies)
            {
                movieDtos.Add(movie.ToDto());
            }
            Console.WriteLine(movieDtos.Count);
            return movieDtos;
        }
    }
}