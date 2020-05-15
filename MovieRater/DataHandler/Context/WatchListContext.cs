using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataHandler.Context
{
    class WatchListContext
    {
        public string ConnectionString { get; set; }

        public WatchListContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<WatchList> GetWatchListViewModels()
        {
            string command = "select * from watchlist;";
            List<WatchList> watchLists = new List<WatchList>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    watchLists.Add(new WatchList()
                    {
                        UserID = reader.GetInt32(0),
                        MovieID = reader.GetInt32(1)
                    });

                }
            }
            return watchLists;
        }
    }
}
