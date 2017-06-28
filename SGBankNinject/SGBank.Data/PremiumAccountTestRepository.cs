using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class PremiumAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Premium Account",
            AccountNumber = "22222",
            Balance = 100.00M,
            Type = AccountType.Premium
        };
            
        public Account LoadAccount(string accountNumber)
        {
            if (_account.AccountNumber != accountNumber)
            {
                return null;
            }
            else
            {
                return _account;
            }
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
