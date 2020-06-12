using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterfaces
{
    public interface IAccountCollection
    {
        List<IAccount> GetAccounts();
        IAccount GetAccount(string UserName);
        int CreateAccount(IAccount account);
    }
}
