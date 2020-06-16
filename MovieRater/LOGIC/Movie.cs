using System;
using System.Collections.Generic;
using System.Text;

using DataHandlerInterfaces;

using Microsoft.AspNetCore.Http;
using MovieRaterDtos;

namespace Logic
{
    public class Movie
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

        public Movie()
        {

        }

        public Movie(MovieDto movie)
        {
            this.MovieID = movie.MovieID;
            this.Poster = movie.Poster;
            this.Files = movie.Files;
            this.MovieTitle = movie.MovieTitle;
            this.MovieInfo = movie.MovieInfo;
            this.MovieSummary = movie.MovieSummary;
            this.Trailer = movie.Trailer;
            this.Writers = movie.Writers;
            this.Stars = movie.Stars;
            this.Director = movie.Director;
        }

    }
}
