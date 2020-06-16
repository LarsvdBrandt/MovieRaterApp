using DataHandlerInterfaces;
using Microsoft.AspNetCore.Http;
using MovieRaterDtos;
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

        //Zodat als er een dto wordt meegegeven er een datatable van wordt gemaakt.
        public DataMovie(MovieDto movieDto)
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

        //Zodat ook een lege object kan aanmaken zonder dto mee te geven
        public DataMovie()
        {

        }

        //zet data in ToDto voor door te sturen naar de testcase
        public MovieDto ToDto()
        {
            MovieDto movie = new MovieDto();
            movie.MovieID = this.MovieID;
            movie.MovieTitle = this.MovieTitle;
            movie.MovieSummary = this.MovieSummary;
            movie.Poster = this.Poster;
            movie.Trailer = this.Trailer;
            movie.Writers = this.Writers;
            movie.Stars = this.Stars;
            movie.Director = this.Director;

            return movie;
        }

    }
}
