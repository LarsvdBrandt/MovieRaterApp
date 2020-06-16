using DataHandlerInterfaces;
using Logic;
using LogicTypes;
using MovieRaterDtos;
using MovieRaterMemoryHandler.DataTypes;
using MovieRaterMemoryHandler.Tables;
using MySqlX.XDevAPI.Relational;
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
            foreach (DataMovie movie in movieTable.Movies){
                if(movie.MovieID == movieID)
                {
                    movieTable.Movies.Remove(movie);
                }
            }
        }

        public void EditMovie(Movie movie)
        {
            foreach(DataMovie dataMovie in movieTable.Movies)
            {
                if(dataMovie.MovieID == movie.MovieID)
                {
                    dataMovie.MovieTitle = movie.MovieTitle;
                    dataMovie.Director = movie.Director;
                    dataMovie.Writers = movie.Writers;
                    dataMovie.Stars = movie.Stars;
                    dataMovie.MovieInfo = movie.MovieInfo;
                    dataMovie.MovieSummary = movie.MovieSummary;
                    dataMovie.Poster = movie.Poster;
                    dataMovie.Trailer = movie.Trailer;
                }
            }
        }

        public MovieDto GetMovie(int movieID)
        {
            foreach(DataMovie dataMovie in movieTable.Movies)
            {
                if(dataMovie.MovieID == movieID)
                {
                    return dataMovie.ToDto();
                }
            }
            return null;
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