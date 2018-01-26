using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class Bank
    {
        public string Name { get; set; }

        public List<Account> Accounts { get; } = new List<Account>();
       
        public Bank(string bankName)
        {
            if (String.IsNullOrEmpty(bankName))
                throw new ArgumentNullException($"Bank Name can not be null.");

            this.Name = bankName;
        }


        public Bank(string bankName, List<Account> accounts)
        {
            if (String.IsNullOrEmpty(bankName))
                throw new ArgumentNullException($"Bank Name can not be null.");

            this.Name = bankName;
            this.Accounts = accounts;
           
        }

        public void AddAccount(Account acc)
        {
            if (acc == null)
                throw new ArgumentNullException($"Account can not be null.");

            this.Accounts.Add(acc);
        }

    }
}
