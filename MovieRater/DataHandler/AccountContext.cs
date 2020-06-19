using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

using DataHandlerInterfaces;
using MovieRaterDtos;

namespace DataHandler
{
    public class AccountContext : IAccountRepository
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

        public List<AccountDto> GetAccounts()
        {
            string command = "SELECT * FROM user;";
            List<AccountDto> accountDtos = new List<AccountDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    accountDtos.Add(new AccountDto()
                    {
                        UserID = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        LastName = reader.GetString(3),
                        Email = reader.GetString(4),
                        PhoneNumber = reader.GetInt32(5),
                        Password = reader.GetString(6)
                    });
                }
            }
            return accountDtos;
        }

        public AccountDto GetAccount(string UserName)
        {
            string command = "select * from movie WHERE UserName='{0}';";
            AccountDto accountModels = new AccountDto();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, UserName.ToString()), conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    accountModels = new AccountDto()
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        UserName = reader["UserName"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = Convert.ToInt32(reader["PhoneNumber"]),
                        Password = reader["Password"].ToString()
                    };

                }
            }
            return accountModels;
        }

        public int CreateAccount(AccountDto accountDto)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string command = "INSERT INTO user (UserID, UserName, FirstName, LastName, Email, PhoneNumber, Password) " +
                    "values ({0}, '{1}', '{2}', '{3}', '{4}', {5}, '{6}')";
                MySqlCommand cmd = new MySqlCommand(string.Format(command, accountDto.UserID, accountDto.UserName, accountDto.FirstName, accountDto.LastName,
                    accountDto.Email, accountDto.PhoneNumber, accountDto.Password), conn);
                int rowcount = cmd.ExecuteNonQuery();
                return rowcount;
            }
        }

    }
}
