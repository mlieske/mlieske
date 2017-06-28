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
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, 50, 100, false)] //withdraw a positive number
        [TestCase("22222", "Premium Account", 100, AccountType.Free, -50, 100, false)] //wrong account type
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, -700, 100, false)] //Overdraft
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, -50, 50, true)] //Overdraft
        public void TestWithdrawPremiumAccountTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw premiumWithdraw = new PremiumAccountWithdrawRules();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = premiumWithdraw.Withdraw(account, amount);
            Assert.AreEqual(expectedResult, response.Success);
            Assert.AreEqual(newBalance, account.Balance);
        }

        [TestCase("22222", "Premium Account", 100, AccountType.Premium, -50, 100, false)] //withdraw a positive number
        [TestCase("22222", "Premium Account", 100, AccountType.Free, 50, 100, false)] //wrong account type
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, 700, 800, true)] //Overdraft
        public void TestDepositPremiumAccountTest(string accountNumber, string name, decimal balance,
        AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IDeposit premiumDeposit = new NoLimitDepositRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositResponse response = premiumDeposit.Deposit(account, amount);
            Assert.AreEqual(expectedResult, response.Success);
            Assert.AreEqual(newBalance, account.Balance);
        }
    }
}
