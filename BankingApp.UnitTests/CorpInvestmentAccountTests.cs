using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankingApp.UnitTests
{
    [TestClass]
    public class CorpInvestmentAccountTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
           "Account must have an owner")]
        public void NullCorpInvestmentAccountOwner_InAccountConstructor_ThrowsException()
        {
            CorpInvestmentAccount acc1 = new CorpInvestmentAccount(null, "ABC1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account must have an owner")]
        public void EmptyCorpInvestmentAccOwner_InAccountConstructor_ThrowsException()
        {
            CorpInvestmentAccount acc1 = new CorpInvestmentAccount("", "ABC1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account Number can not be null.")]
        public void NullCorpInvestmentAccNumber_InAccountConstructor_ThrowsException()
        {
            CorpInvestmentAccount acc1 = new CorpInvestmentAccount("Ismail Bilgin", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account Number can not be null.")]
        public void EmptyCorpInvestmentAccNumber_InAccountConstructor_ThrowsException()
        {
            CorpInvestmentAccount acc1 = new CorpInvestmentAccount("Ismail Bilgin", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "You can not deposit negative amount to your account.")]
        public void DepositNegativeAmount_InCorpInvestmentAcc_ThrowsException()
        {
            CorpInvestmentAccount acc1 = new CorpInvestmentAccount("Ismail Bilgin", "ABC1");
            // Add some money to account
            acc1.Deposit(-100);
        }

        [TestMethod]
        public void Deposit_InCorpInvestmentAcc_BalanceEqualToDepositAmount()
        {
            CorpInvestmentAccount acc1 = new CorpInvestmentAccount("Ismail Bilgin", "ABC1");
            // Add some money to account
            acc1.Deposit(1500m);
            // Check balance
            Assert.AreEqual(1500m, acc1.AccBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "You can not withdraw negative amount from your account.")]
        public void WithdrawNegativeAmount_InCorpInvestmentAcc_ThrowsException()
        {
            CorpInvestmentAccount acc1 = new CorpInvestmentAccount("Ismail Bilgin", "ABC1");
            // Withdraw some money from account
            acc1.Withdraw(-100);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Minimum Balance Limit is reached. It is not permissible to overdraft an account")]
        public void WithdrawMinBalanceReached_InCorpInvestmentAcc_ThrowsException()
        {
            CorpInvestmentAccount acc1 = new CorpInvestmentAccount("Ismail Bilgin", "ABC1");
            // Add some money to account
            acc1.Deposit(1000m);
            // Withdraw some money from account
            acc1.Withdraw(1500m);
        }

        [TestMethod]

        public void Withdraw_InCorpInvestmentAcc_BalanceEq500()
        {
            CorpInvestmentAccount acc1 = new CorpInvestmentAccount("Ismail Bilgin", "ABC1");

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
        public void TransferNegativeAmount_InCorpInvestmentAcc_ThrowsException()
        {
            // Create source and destination accounts
            CorpInvestmentAccount source = new CorpInvestmentAccount("Ismail Bilgin", "ABC1");

            CorpInvestmentAccount dest = new CorpInvestmentAccount("Jay Hawkins", "ABC2");

            // Add some money to both accounts
            source.Deposit(3000m);
            dest.Deposit(1000m);

            // Transfer 500 from source to destination
            source.Transfer(-500m, dest);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "You can not transfer money to a unknown account.")]
        public void TransferToUnknownAcc_InCorpInvestmentAcc_ThrowsException()
        {
            // Create source and destination accounts
            CorpInvestmentAccount source = new CorpInvestmentAccount("Ismail Bilgin", "ABC1");

            // Add some money to source account
            source.Deposit(3000m);


            // Transfer 500 from source to destination
            source.Transfer(500m, null);
        }

        [TestMethod]
        public void TransferAmount_InCorpInvestmentAcc_ThrowsException()
        {
            // Create source and destination accounts
            CorpInvestmentAccount source = new CorpInvestmentAccount("Ismail Bilgin", "ABC1");

            CorpInvestmentAccount dest = new CorpInvestmentAccount("Jay Hawkins", "ABC2");

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
