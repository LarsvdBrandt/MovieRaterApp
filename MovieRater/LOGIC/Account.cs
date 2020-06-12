using System;
using System.Collections.Generic;
using System.Text;
using LogicInterfaces;
using DataHandlerInterfaces;
using DataHandlerFactory;
using Microsoft.AspNetCore.Http;

namespace Logic
{
    public class Account : IAccount
    {
        private IAccountContext db;
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }

        public Account()
        {
            db = Factory.GetAccountContext();
        }
    }
}
