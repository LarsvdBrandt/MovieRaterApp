using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IMovie
    {
        public int MovieID { get; set; }
        public string Poster { get; set; }
        public string MovieTitle { get; set; }
        public string MovieInfo { get; set; }
        public string MovieSummary { get; set; }
        public string Trailer { get; set; }
        public string Writers { get; set; }
        public string Stars { get; set; }
        public string Director { get; set; }

        public void EditMovie();
        public void DeleteMovie();
    }
}
