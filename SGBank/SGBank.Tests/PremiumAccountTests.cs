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
    

        [TestFixture]
        public class PremiumAccountTests
        {

            [Test]

            [TestCase("33333", "Premium Account", 100, AccountType.Free, 250, false)] //false because wrong account type
            [TestCase("33333", "Premium Account", 100, AccountType.Premium, -100, false)] //false because you can't have a negative deposit
            [TestCase("33333", "Premium Account", 100, AccountType.Premium, 250, true)] //true because premium account can handle a large deposit

            public void PremiumAccountDepositRuleTest(string accountNumber, string name,
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

            [TestCase("33333", "Premium Account", 1500, AccountType.Premium, -1000, 500, true)] //true because any size withdrawal is allowed, unless >500 overdraft
            [TestCase("33333", "Premium Account", 100, AccountType.Free, -100, 100, false)] //false because wrong account type
            [TestCase("33333", "Premium Account", 100, AccountType.Premium, 100, 100, false)] //false must have a negative withdrawal
            [TestCase("33333", "Premium Account", 100, AccountType.Premium, -600, -500, true)] //overdraft up to $500 with no penalty


            public void PremiumAccountWithdrawRuleTest(string accountNumber, string name,
            decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
            {
                //Arrange
                IWithdraw withdrawRule = new PremiumAccountWithdrawRule();  //Instantiate the class, and only one class for each test

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
                   // Assert.AreEqual(balance, newBalance);
                
            }

        }

    }

