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

        private IAccountRepository db;

        //UNIT TEST
        //Hier zet ik de moviecontext in.
        //Ga door MovieMemoryHandler 
        public AccountCollection(IAccountRepository context)
        {
            this.db = context;
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
            List<Account> accounts = new List<Account>();
            List<AccountDto> accountDtos = db.GetAccounts();
            foreach (AccountDto account in accountDtos)
            {
                accounts.Add(new Account(account));
            }
            return accounts;
        }

        public Account GetAccount(string UserName)
        {
            List<Account> accounts = new List<Account>();

            List<AccountDto> accountDtos = db.GetAccounts();
            foreach (AccountDto accountDto in accountDtos)
            {
                accounts.Add(new Account(accountDto));
            }

            return accounts.Where(model => model.UserName == UserName).FirstOrDefault();
        }
    }
}
