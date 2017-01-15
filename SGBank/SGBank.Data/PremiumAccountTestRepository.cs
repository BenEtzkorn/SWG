using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;


namespace SGBank.Data
{
    public class PremiumAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Premium Account",
            Balance = 1000.00M,
            AccountNumber = "33333",
            Type = AccountType.Premium
        };

        public Account LoadAccount(string AccountNumber)
        {

            if (AccountNumber != "33333")
            {
                return null;
            }

            return _account;

        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
