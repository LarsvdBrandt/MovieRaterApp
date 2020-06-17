using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using MovieRaterDtos;

namespace LogicTypes
{
    public class Account
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }

        public Account()
        {

        }

        public Account(AccountDto account)
        {
            this.UserID = account.UserID;
            this.UserName = account.UserName;
            this.LastName = account.LastName;
            this.LastName = account.LastName;
            this.Email = account.Email;
            this.PhoneNumber = account.PhoneNumber;
            this.Password = account.Password;
        }
    }
}
