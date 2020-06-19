using MovieRaterDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandlerInterfaces
{
    public interface IAccountRepository
    {
        string ConnectionString { get; set; }

        int CreateAccount(AccountDto accountDto);
        AccountDto GetAccount(string UserName);
        List<AccountDto> GetAccounts();
    }
}
