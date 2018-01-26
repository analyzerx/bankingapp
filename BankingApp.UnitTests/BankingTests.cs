using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApp;

namespace BankingApp.UnitTests
{
    [TestClass]
    public class BankingTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Bank Name can not be null.")]
        public void NullBankName_InBankConstructor_ThrowsException()
        {
            Bank bank1 = new Bank(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Bank Name can not be empty.")]
        public void EmptyBankName_InBankConstructor_ThrowsException()
        {
            Bank bank1 = new Bank("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Bank Name can not be null.")]
        public void NullBankName_InBankConstructor2_ThrowsException()
        {
            Bank bank1 = new Bank(null,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Bank Name can not be empty.")]
        public void EmptyBankName_InBankConstructor2_ThrowsException()
        {
            Bank bank1 = new Bank("",null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account can not be null.")]
        public void AddNullAccount_InBankAddAccount_ThrowsException()
        {
            Bank bank1 = new Bank("CB Bank");

            bank1.AddAccount(null);
        }

        [TestMethod]
        public void AddAccount_InBankAddAccount_CountOneAccount()
        {
            Bank bank1 = new Bank("CB Bank");
            //Check the count of accounts in bank before adding initial account
            Assert.AreEqual(0, bank1.Accounts.Count);

            //Adding account to bank accounts
            CheckingAccount acc1 = new CheckingAccount("Ismail Bilgin","ABC1");
            bank1.AddAccount(acc1);

            //Check the count of accounts in bank after adding initial account
            Assert.AreEqual(1, bank1.Accounts.Count);
        }
    }
}
