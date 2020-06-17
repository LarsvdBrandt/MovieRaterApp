using MovieRaterMemoryHandler.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRaterMemoryHandler.Tables
{
    public class TableAccount
    {
        //Lijst met accounts van de unit test data
        public List<DataAccount> Accounts { get; set; } = new List<DataAccount>();

        //Auto increment voor unit test data
        public int Insert(DataAccount account)
        {
            int id = GetId();

            account.UserID = id;
            Accounts.Add(account);

            return id;
        }

        //Auto increment voor unit test data
        private int GetId()
        {
            int id = 0;

            foreach (DataAccount account in Accounts)
            {
                if (account.UserID > id)
                {
                    id = account.UserID;
                }
            }

            id++;
            return id;
        }
    }
}
