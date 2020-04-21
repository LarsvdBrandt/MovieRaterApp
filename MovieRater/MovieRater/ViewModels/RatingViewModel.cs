using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class RatingViewModel
    {
        public MovieViewModel MovieViewModel { get; set; }

        public List<Rating> Ratings { get; set; }
    }
}
