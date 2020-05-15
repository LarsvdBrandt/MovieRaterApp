using System;
using System.Collections.Generic;
using System.Text;
using DataHandlerInterfaces;

namespace DataHandler.Models
{
    class AccountDto
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
