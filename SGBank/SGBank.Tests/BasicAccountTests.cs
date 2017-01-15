using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    class BasicAccountTests
    {

        [TestFixture]
        public class FreeAccountTests
        {

            [Test]

            [TestCase("22222", "Basic Account", 100, AccountType.Free, 250, false)] //false because wrong account type
            [TestCase("22222", "Basic Account", 100, AccountType.Basic, -100, false)] //false because you can't have a negative deposit
            [TestCase("22222", "Basic Account", 100, AccountType.Basic, 250, true)] //true because basic account can handle a large deposit

            public void BasicAccountDepositRuleTest(string accountNumber, string name,
            decimal balance, AccountType accountType, decimal amount, bool expectedResult)
            {
                //Arrange
                IDeposit depositRule = new NoLimitDepositRule();  //Instantiate the class, and only one class for each test

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

            [TestCase("22222", "Basic Account", 1500, AccountType.Basic, -1000, 1500, false)] //false because too large a withdrawal
            [TestCase("22222", "Basic Account", 100, AccountType.Free, -100, 100, false)] //false because wrong account type
            [TestCase("22222", "Basic Account", 100, AccountType.Basic, 100, 100, false)] //false must have a negative withdrawal
            [TestCase("22222", "Basic Account", 150, AccountType.Basic, -50, 100, true)] //true because basic balance balances
            [TestCase("22222", "Basic Account", 100, AccountType.Basic, -150, -60, true)] //overdraft with penalty


            public void BasicAccountWithdrawRuleTest(string accountNumber, string name,
            decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
            {
                //Arrange
                IWithdraw withdrawRule = new BasicAccountWithdrawRule();  //Instantiate the class, and only one class for each test

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
                
                    Assert.AreEqual(expectedResult, actualResult);
                    //Assert.AreEqual(balance, newBalance);
                
            }

        }

    }
}
