using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class IndInvestmentAccount : Account
    {
        // This field holds the Maximum Wihdraw Amount 
        protected decimal MaxWithdrawAmount { get; set; } 
        public IndInvestmentAccount(string accOwnerName, string accNumber)
            :base(accOwnerName, accNumber)
        {
            this.MinAccBalance = 0m;
            this.MaxWithdrawAmount = 1000m;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException(
                    $"You can not withdraw negative amount from your account.");


            if (AccBalance - amount < MinAccBalance)
                throw new Exception(
                    $"Minimum Balance limit is reached.You can not withdraw {amount} amount from your account");

            if (amount > MaxWithdrawAmount)
                throw new Exception(
                    $"You can not withdraw more than {MaxWithdrawAmount} from your account");

            AccBalance = AccBalance - amount;
            TranxSummary = $"{TranxSummary}\n Withdraw:{amount}, Balance: {AccBalance}";
        }
    }
}
