using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandlerInterfaces
{
    public interface IMovieContext
    {
        string ConnectionString { get; set; }

        int CreateMovie(IMovieDto movieDto);
        void DeleteMovie(int movieID);
        void EditMovie(string MovieTitle, string MovieInfo, string MovieSummary, string Poster, string Trailer, string Writers, string Stars, string Director, int MovieID);
        IMovieDto GetMovie(int movieID);
        List<IMovieDto> GetMovies();
    }
}
