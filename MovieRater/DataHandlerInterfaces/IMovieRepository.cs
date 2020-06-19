using LogicTypes;
using MovieRaterDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandlerInterfaces
{
    public interface IMovieRepository
    {
        string ConnectionString { get; set; }

        int CreateMovie(MovieDto movieDto);
        void DeleteMovie(int movieID);
        void EditMovie(Movie movie);
        MovieDto GetMovie(int movieID);
        List<MovieDto> GetMovies();
    }
}
