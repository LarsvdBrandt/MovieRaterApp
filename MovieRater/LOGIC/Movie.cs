using System;
using System.Collections.Generic;
using System.Text;
using LogicInterfaces;
using DataHandlerInterfaces;
using DataHandlerFactory;
using Microsoft.AspNetCore.Http;

namespace Logic
{
    public class Movie : IMovie
    {
        private IMovieContext db;
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
            db = Factory.GetMovieContext();
        }

        public void EditMovie()
        {
            db.EditMovie(MovieTitle, MovieInfo, MovieSummary, Poster, Trailer, Writers, Stars, Director, MovieID);
        }

        public void DeleteMovie()
        {
            db.DeleteMovie(MovieID);
        }
    }
}
