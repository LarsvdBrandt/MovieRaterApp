using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataHandler.Context
{
    class RatingContext
    {
        public string ConnectionString { get; set; }

        public RatingContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public void AddRating(Rating model)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string command = "INSERT INTO rating (RatingID,MovieID,RatingStars,RatingTitle,RatingComment) " +
                    "values ({0}, '{1}', '{2}', '{3}', '{4}')";
                MySqlCommand cmd = new MySqlCommand(string.Format(command, model.RatingID, model.MovieID, model.RatingStars,
                    model.RatingTitle, model.RatingComment), conn);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Rating> GetRatingViewModels()
        {
            string command = "select * from rating;";
            List<Rating> ratings = new List<Rating>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ratings.Add(new Rating()
                    {
                        RatingID = reader.GetInt32(0),
                        MovieID = reader.GetInt32(1),
                        RatingStars = reader.GetInt32(2),
                        RatingTitle = reader.GetString(3),
                        RatingComment = reader.GetString(4)
                    });

                }
            }
            return ratings;
        }
    }
}
