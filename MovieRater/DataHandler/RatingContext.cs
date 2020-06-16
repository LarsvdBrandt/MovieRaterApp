using System;
using System.Collections.Generic;
using System.Text;
using DataHandlerInterfaces;
using MovieRaterDtos;
using MySql.Data.MySqlClient;

namespace DataHandler
{
    public class RatingContext : IRatingContext
    {
        public string ConnectionString { get; set; }

        public RatingContext()
        {
            ConnectionString = ConnectionStringValue.connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public int CreateRating(RatingDto ratingDto)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string command = "INSERT INTO rating (RatingID,MovieID,RatingStars,RatingTitle,RatingComment) " +
                    "values ({0}, '{1}', '{2}', '{3}', '{4}')";
                MySqlCommand cmd = new MySqlCommand(string.Format(command, ratingDto.RatingID, ratingDto.MovieID, ratingDto.RatingStars,
                    ratingDto.RatingTitle, ratingDto.RatingComment), conn);
                int rowcount = cmd.ExecuteNonQuery();
                return rowcount;
            }
        }

        public List<RatingDto> GetRatings()
        {

            string command = "SELECT * FROM rating;";
            List<RatingDto> ratingDtos = new List<RatingDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ratingDtos.Add(new RatingDto()
                    {
                        RatingID = reader.GetInt32(0),
                        MovieID = reader.GetInt32(1),
                        RatingStars = reader.GetInt32(2),
                        RatingTitle = reader.GetString(3),
                        RatingComment = reader.GetString(4)
                    });
                }
            }
            return ratingDtos;
        }

        public List<RatingDto> GetRatingsMovie(int MovieID)
        {

            string command = "SELECT * FROM rating WHERE MovieID={0};";
            List<RatingDto> ratingDtos = new List<RatingDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, MovieID), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ratingDtos.Add(new RatingDto()
                    {
                        RatingID = reader.GetInt32(0),
                        MovieID = reader.GetInt32(1),
                        RatingStars = reader.GetInt32(2),
                        RatingTitle = reader.GetString(3),
                        RatingComment = reader.GetString(4)
                    });
                }
            }
            return ratingDtos;
        }

        public RatingDto GetRating(int movieID)
        {
            string command = "select * from rating WHERE movieID={0};";
            RatingDto ratingDto = new RatingDto();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, movieID.ToString()), conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ratingDto = new RatingDto()
                    {
                        RatingID = Convert.ToInt32(reader["RatingID"]),
                        MovieID = Convert.ToInt32(reader["MovieID"]),
                        RatingStars = Convert.ToInt32(reader["RatingStars"]),
                        RatingTitle = reader["RatingTitle"].ToString(),
                        RatingComment = reader["RatingComment"].ToString()
                    };

                }
            }
            return ratingDto;
        }
    }
}
