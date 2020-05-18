using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using DataHandler.Models;
using DataHandlerInterfaces;


namespace DataHandler.Context
{
    public class AccountContext : IAccountContext
    {
        public string ConnectionString { get; set; }

        public AccountContext()
        {
            ConnectionString = ConnectionStringValue.connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

    }
}
