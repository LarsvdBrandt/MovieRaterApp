using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using DataHandlerInterfaces;
using MovieRaterDtos;

namespace DataHandler
{
    public class MovieContext : IMovieContext
    {
        public string ConnectionString { get; set; }
        public MovieContext()
        {
            ConnectionString = ConnectionStringValue.connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<MovieDto> GetMovies()
        {
            string command = "SELECT * FROM movie;";
            List<MovieDto> movieDtos = new List<MovieDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movieDtos.Add(new MovieDto()
                    {
                        MovieID = reader.GetInt32(0),
                        MovieTitle = reader.GetString(1),
                        MovieInfo = reader.GetString(2),
                        MovieSummary = reader.GetString(3),
                        Poster = reader.GetString(4),
                        Trailer = reader.GetString(5),
                        Writers = reader.GetString(6),
                        Stars = reader.GetString(7),
                        Director = reader.GetString(8)
                    });
                }
            }
            return movieDtos;
        }
        public MovieDto GetMovie(int MovieID)
        {
            string command = "select * from movie WHERE MovieID='{0}';";
            MovieDto movieModels = new MovieDto();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, MovieID.ToString()), conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movieModels = new MovieDto()
                    {
                        MovieID = Convert.ToInt32(reader["MovieID"]),
                        MovieTitle = reader["MovieTitle"].ToString(),
                        MovieInfo = reader["MovieInfo"].ToString(),
                        MovieSummary = reader["MovieSummary"].ToString(),
                        Poster = reader["Poster"].ToString(),
                        Writers = reader["Writers"].ToString(),
                        Stars = reader["Stars"].ToString(),
                        Director = reader["Director"].ToString()
                    };

                }
            }
            return movieModels;
        }
        public int CreateMovie(MovieDto movieDto)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string command = "INSERT INTO movie (MovieID,MovieTitle,MovieInfo,MovieSummary,Poster,Trailer,Writers,Stars,Director) " +
                    "values ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')";
                MySqlCommand cmd = new MySqlCommand(string.Format(command, movieDto.MovieID, movieDto.MovieTitle, movieDto.MovieInfo, movieDto.MovieSummary,
                                                    movieDto.Poster, movieDto.Trailer, movieDto.Writers, movieDto.Stars, movieDto.Director), conn);
                int rowcount = cmd.ExecuteNonQuery();
                return rowcount;
            }
        }
        public void EditMovie(string MovieTitle, string MovieInfo, string MovieSummary, string Poster, string Trailer, string Writers, string Stars, string Director, int MovieID)
        {
            string command = "UPDATE movie SET MovieTitle='{1}',MovieInfo='{2}',MovieSummary='{3}',Poster='{4}',Trailer='{5}',Writers='{6}',Stars='{7}',Director='{8}' WHERE MovieID='{9}';";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, MovieID, MovieTitle, MovieInfo, MovieSummary,
                                                    Poster, Trailer, Writers, Stars, Director, MovieID), conn);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteMovie(int movieID)
        {
            string command = "DELETE FROM movie WHERE MovieID='{0}';";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, movieID), conn);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
