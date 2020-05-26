using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using DataHandler.Models;
using DataHandlerInterfaces;

namespace DataHandler.Context
{
    public class WatchListContext : IWatchListContext
    {
        public string ConnectionString { get; set; }

        public WatchListContext()
        {
            ConnectionString = ConnectionStringValue.connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public int AddWatchList(IWatchListDto watchListDto)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string command = "INSERT INTO watchlist (UserID,MovieID,WatchListID) " +
                    "values ({0}, {1}, {2})";
                MySqlCommand cmd = new MySqlCommand(string.Format(command, 1, watchListDto.MovieID, watchListDto.WatchListID), conn);
                int rowcount = cmd.ExecuteNonQuery();
                return rowcount;
            }
        }

        public List<IWatchListDto> GetWatchList()
        {
            string command = "SELECT * FROM watchlist WHERE UserID=1;";
            List<IWatchListDto> watchListDtos = new List<IWatchListDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    watchListDtos.Add(new WatchListDto()
                    {
                        UserID = reader.GetInt32(0),
                        MovieID = reader.GetInt32(1),
                        WatchListID = reader.GetInt32(2),
                    });
                }
            }
            return watchListDtos;
        }
    }
}
