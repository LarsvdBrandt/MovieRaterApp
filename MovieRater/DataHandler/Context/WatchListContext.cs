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

        public List<IWatchListDto> GetWatchList()
        {
            string command = "SELECT * FROM watchlist;";
            List<IWatchListDto> watchListDtos = new List<IWatchListDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    watchListDtos.Add(new WatchListDto()
                    {
                        UserID = reader.GetInt32(0),
                        MovieID = reader.GetInt32(1),
                        WatchListID = reader.GetInt32(2)
                    });
                }
            }
            return watchListDtos;
        }
    }
}
