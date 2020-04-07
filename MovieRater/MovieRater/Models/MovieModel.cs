using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }
        public string Poster { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Film titel")]
        public string Title { get; set; }
    }

}
