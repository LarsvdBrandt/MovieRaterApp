using DataHandlerInterfaces;
using Logic;
using LogicTypes;
using MovieRaterDtos;
using MovieRaterMemoryHandler.DataTypes;
using MovieRaterMemoryHandler.Tables;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRaterMemoryHandler
{
    public class AccountMemoryHandler : IAccountContext
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private TableAccount accountTable;

        //Data van tabel ophalen
        public AccountMemoryHandler(MemoryTables tables)
        {
            this.accountTable = tables.accounts;
        }

        //In de tabel data van accountDto zetten
        public int CreateAccount(AccountDto accountDto)
        {
            return accountTable.Insert(new DataAccount(accountDto));
        }

        public AccountDto GetAccount(string UserName)
        {
            foreach (DataAccount dataAccount in accountTable.Accounts)
            {
                if (dataAccount.UserName == UserName)
                {
                    return dataAccount.ToDto();
                }
            }
            return null;
        }

        //door de lijst van memorytable loopen om zo alle accounts in een lijst te zetten.
        public List<AccountDto> GetAccounts()
        {
            List<AccountDto> accountDtos = new List<AccountDto>();
            foreach (DataAccount account in accountTable.Accounts)
            {
                accountDtos.Add(account.ToDto());
            }
            return accountDtos;
        }
    }
}
