using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataHandler.Context
{
    class MovieContext
    {
        public string ConnectionString { get; set; }

        public MovieContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<MovieViewModel> GetMovieModels()
        {
            string command = "select * from movie;";
            List<MovieViewModel> movieModels = new List<MovieViewModel>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movieModels.Add(new MovieViewModel()
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
            return movieModels;
        }

        public void AddMovie(MovieViewModel model)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string command = "INSERT INTO movie (MovieID,MovieTitle,MovieInfo,MovieSummary,Poster,Trailer,Writers,Stars,Director) " +
                    "values ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')";
                MySqlCommand cmd = new MySqlCommand(string.Format(command, model.MovieID, model.MovieTitle, model.MovieInfo, model.MovieSummary,
                                                    model.Poster, model.Trailer, model.Writers, model.Stars, model.Director), conn);
                cmd.ExecuteNonQuery();
            }
        }
        public void EditMovie(EditMovieViewModel model)
        {
            string command = "UPDATE movie SET MovieID='{0}',MovieTitle='{1}',MovieInfo='{2}',MovieSummary='{3}',Poster='{4}',Trailer='{5}',Writers='{6}',Stars='{7}',Director='{8}' WHERE MovieID='{9}';";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, model.MovieID, model.MovieTitle, model.MovieInfo, model.MovieSummary, model.Poster, model.Trailer, model.Writers, model.Stars, model.Director, model.MovieID), conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMovie(EditMovieViewModel model)
        {
            string command = "DELETE FROM movie WHERE MovieID='{0}';";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, model.MovieID), conn);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
