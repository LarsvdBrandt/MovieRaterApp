﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

using DataHandlerInterfaces;
using MovieRaterDtos;

namespace DataHandler
{
    public class WatchListContext : IWatchListRepository
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
        public int CreateWatchList(WatchListDto watchListDto)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string command = "INSERT INTO watchlist (MovieID, UserID)" +
                    "values ({0}, {1})";
                MySqlCommand cmd = new MySqlCommand(string.Format(command, watchListDto.MovieID, 1), conn);
                int rowcount = cmd.ExecuteNonQuery();
                return rowcount;
            }
        }

        public List<WatchListDto> GetWatchListMovie()
        {
            string command = "SELECT * FROM movie WHERE MovieID IN (SELCT MovieID FROM watchlist WHERE UserID = 1;)";
            List<WatchListDto> watchListDtos = new List<WatchListDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    watchListDtos.Add(new WatchListDto()
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
            return watchListDtos;
        }

        public List<WatchListDto> GetWatchList()
        {
            string command = "SELECT * FROM movie";
            List<WatchListDto> watchListDtos = new List<WatchListDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    watchListDtos.Add(new WatchListDto()
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
            return watchListDtos;
        }
    }
}
