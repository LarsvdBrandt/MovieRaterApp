using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.ViewModels
{
    public class MovieIndexViewModel
    {
        public List<IMovie> Movies { get; set; }
    }
}
