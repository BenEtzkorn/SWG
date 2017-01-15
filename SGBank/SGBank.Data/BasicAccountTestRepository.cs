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
    public class BasicAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Basic Account",
            Balance = 500.00M,
            AccountNumber = "22222",
            Type = AccountType.Basic
        };

        public Account LoadAccount(string AccountNumber)
        {
            if (AccountNumber != "22222")
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
