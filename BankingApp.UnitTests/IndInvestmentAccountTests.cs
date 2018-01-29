using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankingApp.UnitTests
{
    [TestClass]
    public class IndInvestmentAccountTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
           "Account must have an owner")]
        public void NullIndInvestmentAccountOwner_InAccountConstructor_ThrowsException()
        {
            IndInvestmentAccount acc1 = new IndInvestmentAccount(null, "ABC1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account must have an owner")]
        public void EmptyIndInvestmentAccOwner_InAccountConstructor_ThrowsException()
        {
            IndInvestmentAccount acc1 = new IndInvestmentAccount("", "ABC1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account Number can not be null.")]
        public void NullIndInvestmentAccNumber_InAccountConstructor_ThrowsException()
        {
            IndInvestmentAccount acc1 = new IndInvestmentAccount("Ethan Hawk", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Account Number can not be null.")]
        public void EmptyIndInvestmentAccNumber_InAccountConstructor_ThrowsException()
        {
            IndInvestmentAccount acc1 = new IndInvestmentAccount("Ethan Hawk", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "You can not deposit negative amount to your account.")]
        public void DepositNegativeAmount_InIndInvestmentAcc_ThrowsException()
        {
            IndInvestmentAccount acc1 = new IndInvestmentAccount("Ethan Hawk", "ABC1");
            // Add some money to account
            acc1.Deposit(-100);
        }

        [TestMethod]
        public void Deposit_InIndInvestmentAcc_BalanceEqualToDepositAmount()
        {
            IndInvestmentAccount acc1 = new IndInvestmentAccount("Ethan Hawk", "ABC1");
            // Add some money to account
            acc1.Deposit(1500m);
            // Check balance
            Assert.AreEqual(1500m, acc1.AccBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "You can not withdraw negative amount from your account.")]
        public void WithdrawNegativeAmount_InIndInvestmentAcc_ThrowsException()
        {
            IndInvestmentAccount acc1 = new IndInvestmentAccount("Ethan Hawk", "ABC1");
            // Withdraw some money from account
            acc1.Withdraw(-100);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Minimum Balance Limit is reached. It is not permissible to overdraft an account")]
        public void WithdrawMinBalanceReached_InIndInvestmentAcc_ThrowsException()
        {
            IndInvestmentAccount acc1 = new IndInvestmentAccount("Ethan Hawk", "ABC1");
            // Add some money to account
            acc1.Deposit(1000m);
            // Withdraw some money from account
            acc1.Withdraw(1500m);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Maximum Withdraw Limit is reached")]
        public void WithdrawMaxLimitReached_InIndInvestmentAcc_ThrowsException()
        {
            IndInvestmentAccount acc1 = new IndInvestmentAccount("Ethan Hawk", "ABC1");
            // Add some money to account
            acc1.Deposit(2000m);
            // Withdraw some money from account
            acc1.Withdraw(1500m);
        }

        [TestMethod]

        public void Withdraw_InIndInvestmentAcc_BalanceEq500()
        {
            IndInvestmentAccount acc1 = new IndInvestmentAccount("Ethan Hawk", "ABC1");

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
        public void TransferNegativeAmount_InIndInvestmentAcc_ThrowsException()
        {
            // Create source and destination accounts
            IndInvestmentAccount source = new IndInvestmentAccount("Ethan Hawk", "ABC1");

            IndInvestmentAccount dest = new IndInvestmentAccount("Jay Hawkins", "ABC2");

            // Add some money to both accounts
            source.Deposit(3000m);
            dest.Deposit(1000m);

            // Transfer 500 from source to destination
            source.Transfer(-500m, dest);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "You can not transfer money to a unknown account.")]
        public void TransferToUnknownAcc_InIndInvestmentAcc_ThrowsException()
        {
            // Create source and destination accounts
            IndInvestmentAccount source = new IndInvestmentAccount("Ethan Hawk", "ABC1");

            // Add some money to source account
            source.Deposit(3000m);


            // Transfer 500 from source to destination
            source.Transfer(500m, null);
        }

        [TestMethod]
        public void TransferAmount_InIndInvestmentAcc_ThrowsException()
        {
            // Create source and destination accounts
            IndInvestmentAccount source = new IndInvestmentAccount("Ethan Hawk", "ABC1");

            IndInvestmentAccount dest = new IndInvestmentAccount("Jay Hawkins", "ABC2");

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
