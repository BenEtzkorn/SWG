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
    public class FreeAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Free Account",
            Balance = 100.00M,
            AccountNumber = "11111",
            Type = AccountType.Free
        };

        public Account LoadAccount(string AccountNumber)
        {

            if (AccountNumber != "11111")
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
