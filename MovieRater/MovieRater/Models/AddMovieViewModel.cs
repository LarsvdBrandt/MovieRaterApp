using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class AddMovieViewModel
    {
        [Key]
        public int MovieID { get; set; }

        [Display(Name = "Foto")]
        public ICollection<IFormFile> Poster { get; set; }

        [Display(Name = "Titel")]
        public string MovieTitle { get; set; }

        [Display(Name = "Info")]
        public string MovieInfo { get; set; }

        [Display(Name = "Samenvatting")]
        public string MovieSummary { get; set; }

        [Display(Name = "Trailer")]
        public string Trailer { get; set; }

        [Display(Name = "Schrijvers")]
        public string Writers { get; set; }

        [Display(Name = "Acteurs")]
        public string Stars { get; set; }

        [Display(Name = "Director")]
        public string Director { get; set; }
    }
}
