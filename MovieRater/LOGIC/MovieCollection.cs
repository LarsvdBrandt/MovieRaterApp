using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandlerInterfaces;
using System.Linq;
using MovieRaterDtos;
using LogicTypes;

namespace Logic
{
    public class MovieCollection
    {
        private IMovieRepository db;

        //UNIT TEST
        //Hier zet ik de moviecontext in.
        //Ga door MovieMemoryHandler 
        public MovieCollection(IMovieRepository context)
        {
            this.db = context;
        }

        public int CreateMovie(Movie movie)
        {
            MovieDto movieDto = new MovieDto();
            movieDto.MovieTitle = movie.MovieTitle;
            movieDto.MovieSummary = movie.MovieSummary;
            movieDto.Poster = movie.Poster;
            movieDto.Trailer = movie.Trailer;
            movieDto.Writers = movie.Writers;
            movieDto.Stars = movie.Stars;
            movieDto.Director = movie.Director;

            int rowcount = db.CreateMovie(movieDto);
            return rowcount;
        }
        
        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            List<MovieDto> movieDtos = db.GetMovies();
            foreach (MovieDto movie in movieDtos)
            {
                movies.Add(new Movie(movie));
            }
            return movies;
        }

        public Movie GetMovie(int MovieID)
        {
            List<Movie> movies = new List<Movie>();

            List<MovieDto> movieDtos = db.GetMovies();
            foreach (MovieDto movieDto in movieDtos)
            {
                movies.Add(new Movie(movieDto));
            }

            return movies.Where(model => model.MovieID == MovieID).FirstOrDefault();
        }

        public void EditMovie(Movie movie)
        {
            db.EditMovie(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            db.DeleteMovie(movie.MovieID);
        }

    }
}
