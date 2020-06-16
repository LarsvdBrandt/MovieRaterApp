using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Http;

namespace LogicTypes
{
    public class WatchList
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
    }
}
