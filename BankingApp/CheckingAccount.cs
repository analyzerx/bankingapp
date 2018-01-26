using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(string accOwnerName, string accNumber)
            :base(accOwnerName, accNumber)
        {
            this.MinAccBalance = 0m;
        }

    }
}
