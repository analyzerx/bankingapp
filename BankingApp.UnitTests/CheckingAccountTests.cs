using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankingApp.UnitTests
{
    [TestClass]
    public class CheckingAccountTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account must have an owner")]
        public void NullCheckingAccountOwner_InAccountConstructor_ThrowsException()
        {
            CheckingAccount acc1 = new CheckingAccount(null, "ABC1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account must have an owner")]
        public void EmptyCheckingAccountOwner_InAccountConstructor_ThrowsException()
        {
            CheckingAccount acc1 = new CheckingAccount("", "ABC1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account Number can not be null.")]
        public void NullCheckingAccountNumber_InAccountConstructor_ThrowsException()
        {
            CheckingAccount acc1 = new CheckingAccount("Ethan Hawk", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account Number can not be null.")]
        public void EmptyCheckingAccountNumber_InAccountConstructor_ThrowsException()
        {
            CheckingAccount acc1 = new CheckingAccount("Ethan Hawk", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "You can not deposit negative amount to your account.")]
        public void DepositNegativeAmount_InCheckingAccount_ThrowsException()
        {
            CheckingAccount acc1 = new CheckingAccount("Ethan Hawk", "ABC1");
            // Add some money to account
            acc1.Deposit(-100);
        }

        [TestMethod]
        public void Deposit_InCheckingAccount_BalanceEqualToDepositAmount()
        {
            CheckingAccount acc1 = new CheckingAccount("Ethan Hawk", "ABC1");
            // Add some money to account
            acc1.Deposit(1500m);
            // Check balance
            Assert.AreEqual(1500m, acc1.AccBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "You can not withdraw negative amount from your account.")]
        public void WithdrawNegativeAmount_InCheckingAccount_ThrowsException()
        {
            CheckingAccount acc1 = new CheckingAccount("Ethan Hawk", "ABC1");
            // Withdraw some money from account
            acc1.Withdraw(-100);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Minimum Balance Limit is reached. It is not permissible to overdraft an account")]
        public void WithdrawMinBalanceReached_InCheckingAccount_ThrowsException()
        {
            CheckingAccount acc1 = new CheckingAccount("Ethan Hawk", "ABC1");
            // Add some money to account
            acc1.Deposit(1000m);
            // Withdraw some money from account
            acc1.Withdraw(1500m);
        }

        [TestMethod]
      
        public void Withdraw_InCheckingAccount_BalanceEq500()
        {
            CheckingAccount acc1 = new CheckingAccount("Ethan Hawk", "ABC1");

            // Add some money to account
            acc1.Deposit(1500m);

            // Withdraw some money from account
            acc1.Withdraw(1000m);
            
            // Check balance
            Assert.AreEqual(500m, acc1.AccBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "You can not transfer negative amount from your account.")]
        public void TransferNegativeAmount_InCheckingAccount_ThrowsException()
        {
            // Create source and destination accounts
            CheckingAccount source = new CheckingAccount("Ethan Hawk", "ABC1");

            CheckingAccount dest = new CheckingAccount("Jay Hawkins", "ABC2");

            // Add some money to both accounts
            source.Deposit(3000m);
            dest.Deposit(1000m);

            // Transfer 500 from source to destination
            source.Transfer(-500m, dest);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "You can not transfer money to a unknown account.")]
        public void TransferToUnknownAcc_InCheckingAccount_ThrowsException()
        {
            // Create source and destination accounts
            CheckingAccount source = new CheckingAccount("Ethan Hawk", "ABC1");

            // Add some money to source account
            source.Deposit(3000m);
          

            // Transfer 500 from source to destination
            source.Transfer(500m, null);
        }

        [TestMethod]
        public void TransferAmount_InCheckingAccount_ThrowsException()
        {
            // Create source and destination accounts
            CheckingAccount source = new CheckingAccount("Ethan Hawk", "ABC1");

            CheckingAccount dest = new CheckingAccount("Jay Hawkins", "ABC2");

            // Add some money to both accounts
            source.Deposit(3000m);
            dest.Deposit(1000m);

            // Transfer 500 from source to destination
            source.Transfer(500m, dest);

            // Check balances in each account
            Assert.AreEqual(2500m, source.AccBalance);
            Assert.AreEqual(1500m, dest.AccBalance);
           
        }







    }
}
