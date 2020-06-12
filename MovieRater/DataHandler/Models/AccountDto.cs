using System;
using System.Collections.Generic;
using System.Text;
using DataHandlerInterfaces;

namespace DataHandler.Models
{
    public class AccountDto : IAccountDto
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
