using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandlerInterfaces;
using System.Linq;
using MovieRaterDtos;
using DataHandler;
using LogicTypes;

namespace Logic
{
    public class AccountCollection
    {

        private IAccountContext db;
        private List<Account> accounts;
        public AccountCollection()
        {
            db = new AccountContext();
            accounts = new List<Account>();
            List<AccountDto> accountDtos = db.GetAccounts();
            foreach (AccountDto accountDto in accountDtos)
            {
                accounts.Add(new Account()
                {
                    UserID = accountDto.UserID,
                    UserName = accountDto.UserName,
                    FirstName = accountDto.FirstName,
                    LastName = accountDto.LastName,
                    Email = accountDto.Email,
                    PhoneNumber = accountDto.PhoneNumber,
                    Password = accountDto.Password
                });
            }
        }

        public int CreateAccount(Account account)
        {
            AccountDto accountDto = new AccountDto(); ;
            accountDto.UserID = account.UserID;
            accountDto.UserName = account.UserName;
            accountDto.FirstName = account.FirstName;
            accountDto.LastName = account.LastName;
            accountDto.Email = account.Email;
            accountDto.PhoneNumber = account.PhoneNumber;
            accountDto.Password = account.Password;

            int rowcount = db.CreateAccount(accountDto);
            return rowcount;
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }

        public Account GetAccount(string UserName)
        {
            return accounts.Where(model => model.UserName == UserName).FirstOrDefault();
        }
    }
}
