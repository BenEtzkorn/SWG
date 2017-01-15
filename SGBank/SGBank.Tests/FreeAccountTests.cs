using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.Data;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL.WithdrawRules;

namespace SGBank.Tests
{
    [TestFixture]
    public class AccountTests
    {

        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("11111", response.Account.AccountNumber);
        }

        [Test]
        [TestCase("11111", "Free Account", 100, AccountType.Free,250,false)] //false because too large a deposit
        [TestCase("11111", "Free Account", 100, AccountType.Free, -100, false)] //false because you can't have a negative deposit
        [TestCase("11111", "Free Account", 100, AccountType.Basic, 50, false)] //false because testing Free not Basic
        [TestCase("11111", "Free Account", 100, AccountType.Free, 50, true)] //case should work, so true

        public void FreeAccountDepositRuleTest(string accountNumber, string name,
        decimal balance, AccountType accountType, decimal amount, bool expectedResult)  //Arrange, Act, Assert - AAA in TDD
            {
            //Arrange
            IDeposit depositRule = new FreeAccountDepositRule();  //Instantiate the class, and only one class for each test

            Account account = new Account()
            {

                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType

            };
            
            //Act
            AccountDepositResponse response = depositRule.Deposit(account, amount);
            bool actualResult = response.Success;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        [TestCase("11111", "Free Account", 100, AccountType.Free, -250, false)] //false because too large a withdrawal
        [TestCase("11111", "Free Account", 100, AccountType.Free, 100, false)] //false because can't have a positive withdrawal
        [TestCase("11111", "Free Account", 100, AccountType.Basic, -50, false)] //false because testing Free not Basic
        [TestCase("11111", "Free Account", 100, AccountType.Basic, -101, false)] //false because overdraft
        [TestCase("11111", "Free Account", 100, AccountType.Free, -50, true)] //case should work, so true

        public void FreeAccountWithdrawRuleTest(string accountNumber, string name,
        decimal balance, AccountType accountType, decimal amount, bool expectedResult)  //Arrange, Act, Assert - AAA in TDD
        {
            //Arrange
            IWithdraw withdrawRule = new FreeAccountWithdrawRule();  //Instantiate the class, and only one class for each test

            Account account = new Account()
            {

                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType

            };

            //Act
            AccountWithdrawResponse response = withdrawRule.Withdraw(account, amount);
            bool actualResult = response.Success;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}