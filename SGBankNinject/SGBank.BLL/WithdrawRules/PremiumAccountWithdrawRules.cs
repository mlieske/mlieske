using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class PremiumAccountWithdrawRules : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();
            if (account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error:  Trying to make a premium withdrawal with a non-premium account. Contact IT.";
                return response;
            }
            if (amount > 0)
            {
                response.Success = false;
                response.Message = "Error: Withdrawal must be a negative amount";
                return response;
            }
            if ((account.Balance + amount) < -500)
            {
                response.Success = false;
                response.Message = "Error: Cannot overdraft more than $500";
                return response;
            }

            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;

            return response;
        }
    }
}
