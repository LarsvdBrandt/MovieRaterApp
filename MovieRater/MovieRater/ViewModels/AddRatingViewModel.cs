using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.ViewModels
{
    public class AddRatingViewModel
    {
        public int RatingID { get; set; }
        public int MovieID { get; set; }
        [Display(Name = "Sterren")]
        public int RatingStars { get; set; }
        [Display(Name = "Titel")]
        public string RatingTitle { get; set; }
        [Display(Name = "Commentaar")]
        public string RatingComment { get; set; }
    }
}
