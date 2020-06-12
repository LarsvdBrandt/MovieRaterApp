using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandlerInterfaces;
using DataHandlerFactory;
using LogicInterfaces;
using System.Linq;

namespace Logic
{
    public class MovieCollection : IMovieCollection
    {
        private IMovieContext db;
        private List<IMovie> movies;

        public MovieCollection(IMovieContext context)
        {
            this.db = context;
        }

        public MovieCollection()
        {
            db = Factory.GetMovieContext();
            movies = new List<IMovie>();
            List<IMovieDto> movieDtos = db.GetMovies();
            foreach(IMovieDto movieDto in movieDtos)
            {
                movies.Add(new Movie()
                {
                    MovieID = movieDto.MovieID,
                    MovieTitle = movieDto.MovieTitle,
                    MovieSummary = movieDto.MovieSummary,
                    Poster = movieDto.Poster,
                    Trailer = movieDto.Trailer,
                    Writers = movieDto.Writers,
                    Stars = movieDto.Stars,
                    Director = movieDto.Director
                });
            }
        }

        public int CreateMovie(IMovie movie)
        {
            IMovieDto movieDto = Factory.GetMovieDto();
            movieDto.MovieID = movie.MovieID;
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
        
        public List<IMovie> GetMovies()
        {
            return movies;
        }

        public IMovie GetMovie(int MovieID)
        {
            return movies.Where(model => model.MovieID == MovieID).FirstOrDefault();
        }
    }
}
