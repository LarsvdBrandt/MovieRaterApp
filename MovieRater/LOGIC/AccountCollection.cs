using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataHandlerInterfaces;
using DataHandlerFactory;
using LogicInterfaces;
using System.Linq;

namespace Logic
{
    public class AccountCollection : IAccountCollection
    {

        private IAccountContext db;
        private List<IAccount> accounts;
        public AccountCollection()
        {
            db = Factory.GetAccountContext();
            accounts = new List<IAccount>();
            List<IAccountDto> accountDtos = db.GetAccounts();
            foreach (IAccountDto accountDto in accountDtos)
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

        public int CreateAccount(IAccount account)
        {
            IAccountDto accountDto = Factory.GetAccountDto();
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

        public List<IAccount> GetAccounts()
        {
            return accounts;
        }

        public IAccount GetAccount(string UserName)
        {
            return accounts.Where(model => model.UserName == UserName).FirstOrDefault();
        }
    }
}
