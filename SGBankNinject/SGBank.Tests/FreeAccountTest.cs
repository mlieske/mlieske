using NUnit.Framework;
using SGBank.BLL;
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
    public class FreeAccountTest
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("11111");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("11111", response.Account.AccountNumber);
        }

        [TestCase("12345","Free Account",100,AccountType.Free,250,false)]
        [TestCase("12345","Free Account",100,AccountType.Free,-100,false)]
        [TestCase("12345","Free Account",100,AccountType.Basic,-100,false)]
        [TestCase("12345","Free Account",100,AccountType.Free,50,true)]
        public void FreeAccountDepositRuleTest(string accountNumber, string name, 
            decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit freeDepositRule = new FreeAccountDepositRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            AccountDepositResponse response = freeDepositRule.Deposit(account, amount);
            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, false)]
        [TestCase("12345", "Free Account", 200, AccountType.Free, -150, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -50, false)]
        [TestCase("12345", "Free Account", 50, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -50, true)]
        public void FreeAccountWithdrawRuleTest(string accountNumber, string name,
            decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw freeWithdrawRule = new FreeAccountWithdrawRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            AccountWithdrawResponse response = freeWithdrawRule.Withdraw(account, amount);
            Assert.AreEqual(expectedResult, response.Success);

        }
    }
}
