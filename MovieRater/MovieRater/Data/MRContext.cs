using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MovieRater.Models;

namespace MovieRater.Data
{
    public class MRContext
    {
        public string ConnectionString { get; set; }

        public MRContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<MovieModel> GetMovieModels()
        {
            string command = "select * from movie;";
            List<MovieModel> movieModels = new List<MovieModel>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movieModels.Add(new MovieModel()
                    {
                        MovieID = reader.GetInt32(0),
                        MovieTitle = reader.GetString(1),
                        MovieInfo = reader.GetString(2),
                        MovieSummary = reader.GetString(3),
                        Poster = reader.GetString(4)
                    });
                        
                }
            }
            return movieModels;
        }
    }
}
