using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandlerInterfaces
{
    public interface IAccountContext
    {
        string ConnectionString { get; set; }

        int CreateAccount(IAccountDto accountDto);
        IAccountDto GetAccount(string UserName);
        List<IAccountDto> GetAccounts();
    }
}
