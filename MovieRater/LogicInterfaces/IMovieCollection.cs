using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IMovieCollection
    {
        List<IMovie> GetMovies();
        IMovie GetMovie(int movieID);
        int CreateMovie(IMovie movie);
    }
}
