using DataHandlerInterfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MovieRaterMemoryHandler.DataTypes
{
    public class DataMovie
    {
        public int MovieID { get; set; }
        public string Poster { get; set; }
        public ICollection<IFormFile> Files { get; set; }
        public string MovieTitle { get; set; }
        public string MovieInfo { get; set; }
        public string MovieSummary { get; set; }
        public string Trailer { get; set; }
        public string Writers { get; set; }
        public string Stars { get; set; }
        public string Director { get; set; }

        public DataMovie(IMovieDto movieDto)
        {
            MovieTitle = movieDto.MovieTitle;
            MovieInfo = movieDto.MovieInfo;
            MovieSummary = movieDto.MovieSummary;
            Poster = movieDto.Poster;
            Trailer = movieDto.Trailer;
            Writers = movieDto.Writers;
            Stars = movieDto.Stars;
            Director = movieDto.Director;
        }

        public DataMovie()
        {

        }

    }
}
