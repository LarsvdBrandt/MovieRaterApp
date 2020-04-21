using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class Rating
    {
        [Key]
        [Required]
        public int RatingID { get; set; }
        [Required]
        public int MovieID { get; set; }

        [Display(Name = "Aantal sterren")]
        [Required]
        public int RatingStars { get; set; }
        [Display(Name = "Titel")]
        [Required]
        public string RatingTitle { get; set; }

        [Display(Name = "Commentaar")]
        [Required]
        public string RatingComment { get; set; }
    }
}
