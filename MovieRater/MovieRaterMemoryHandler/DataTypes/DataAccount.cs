using DataHandlerInterfaces;
using Microsoft.AspNetCore.Http;
using MovieRaterDtos;
using System.Collections.Generic;

namespace MovieRaterMemoryHandler.DataTypes
{
    public class DataAccount
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }

        //Zodat als er een dto wordt meegegeven er een datatable van wordt gemaakt.
        public DataAccount(AccountDto accountDto)
        {
            UserName = accountDto.UserName;
            FirstName = accountDto.FirstName;
            LastName = accountDto.LastName;
            Email = accountDto.Email;
            PhoneNumber = accountDto.PhoneNumber;
            Password = accountDto.Password;
        }

        //Zodat ook een lege object kan aanmaken zonder dto mee te geven
        public DataAccount()
        {

        }

        //zet data in ToDto voor door te sturen naar de testcase
        public AccountDto ToDto()
        {
            AccountDto account = new AccountDto();
            account.UserName = this.UserName;
            account.FirstName = this.FirstName;
            account.LastName = this.LastName;
            account.Email = this.Email;
            account.PhoneNumber = this.PhoneNumber;
            account.Password = this.Password;

            return account;
        }
    }
}
