using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public abstract class Account
    {
        // Name of the Account Owner
        public string AccOwnerName { get; set; }

        // Account Number is a common field for all the account types
        public string AccNumber { get; set; }

        // This field holds the account balance
        public decimal AccBalance { get; protected set; }

        // This field holds the MinimumAccount Balance
        protected decimal MinAccBalance { get; set; }

       // This field holds the summary of the transactions 
        protected string TranxSummary { get; set; }

        public Account(string accOwnerName, string accNumber)
        {
            if (String.IsNullOrEmpty(accOwnerName))
                throw new ArgumentNullException($"Account must have an owner.");

            if (String.IsNullOrEmpty(accNumber))
                throw new ArgumentNullException($"Account Number can not be null.");

            this.AccOwnerName = accOwnerName;
            this.AccNumber = accNumber;
            this.TranxSummary = string.Empty;
        }

        //Deposit method can be implemented by the derived classes to give their specific implementation. Therefore it is a virtual method.
        public virtual void Deposit(decimal amount)
        {
            if (amount < 0 )
                throw new ArgumentException(
                    $"You can not deposit negative amount to your account.");

            AccBalance = AccBalance + amount;

            TranxSummary = $"{TranxSummary}\n Deposit:{amount}, Balance: {AccBalance}.";
        }

        //Withdraw method can be implemented by the derived classes to give their specific implementation. Therefore it is a virtual method.
        public virtual void Withdraw(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException(
                    $"You can not withdraw negative amount from your account.");

            if (AccBalance - amount < MinAccBalance)
                throw new Exception(
                    $"Minimum Balance limit {MinAccBalance} is reached.You can not withdraw {amount} amount from your account.");

            AccBalance = AccBalance - amount;
            TranxSummary = $"{TranxSummary}\n Withdraw:{amount}, Balance: {AccBalance}.";
        }

        //Transfer method can be implemented by the derived classes to give their specific implementation. Therefore it is a virtual method.
        public virtual void Transfer(decimal amount, Account toAccount)
        {
            if (amount < 0)
                throw new ArgumentException(
                    $"You can not transfer negative amount from your account.");

            if (toAccount == null)
                throw new ArgumentException(
                    $"You can not transfer money to a unknown account.");

            this.Withdraw(amount);
            toAccount.Deposit(amount);
            /*
            if (AccBalance - amount < MinAccBalance)
                throw new Exception(
                    $"Minimum Balance limit is reached.You can not transfer {amount} amount from your account");

            AccBalance = AccBalance - amount;
            TranxSummary = $"{TranxSummary}\n Withdraw:{amount}, Balance: {AccBalance}";
            */
        }







    }
}
