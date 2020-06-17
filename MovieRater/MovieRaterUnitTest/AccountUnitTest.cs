using Logic;
using LogicFactory;
using LogicTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MovieRaterUnitTest
{
    [TestClass]
    public class AccountUnitTest
    {
        private AccountCollection accountCollection;

        private Account account;
        Factory factory;

        //zet line 10 naar AccountCollection object
        [TestInitialize]
        public void Setup()
        {
            factory = new Factory();
            accountCollection = factory.GetAccountCollection(Context.Memory);
        }

        //Test CreateAccount en GetAccounts
        [TestMethod]
        public void CreateAccount()
        {
            //Setup
            Account insertAccount = new Account()
            {
                UserName = "LarsvandenBrandt",
                FirstName = "Lars",
                LastName = "van den Brandt",
                Email = "Lars.vandenBrandt@icloud.com",
                PhoneNumber = 0636484221,
                Password = "T3stW8woord"
            };

            bool found = false;

            //Action
            accountCollection.CreateAccount(insertAccount);

            //Assert
            foreach (Account account in accountCollection.GetAccounts())
            {
                if (account.UserName.Equals("LarsvandenBrandt"))
                {
                    found = true;
                }
            }
            Assert.IsTrue(found);
        }

        //Test GetAccount
        [TestMethod]
        public void GetAccount()
        {
            //Setup

            //Action
            account = accountCollection.GetAccount("LarsvdB");

            //Assert
            Assert.AreEqual(account.Email, "Lars.vandenBrandt@me.com");
        }
    }
}
