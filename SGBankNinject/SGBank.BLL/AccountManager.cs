using Ninject;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class AccountManager //Load and save account data (repositories do)
    {
        //Want to use different datasets, IAccountRepository allows this
        private IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository) //can't function without a repository so make it part of the constructor
        {
            _accountRepository = accountRepository;
        }

        public AccountLookupResponse LookupAccount(string accountNumber)
        {
            AccountLookupResponse response = new AccountLookupResponse();
            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"Account {accountNumber} is not a valid account.";
                return response;
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public AccountDepositResponse Deposit(string accountNumber, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();
            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"Account {accountNumber} is not a valid account.";
                return response;
            }
            else
            {
                response.Success = true;
            }

            IDeposit depositRule = DepositRulesFactory.Create(response.Account.Type);
            //IDeposit depositRule = DIContainer.Kernel.Get<IDeposit>();

            response = depositRule.Deposit(response.Account, amount);
            if (response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }
            return response;
        }

        public AccountWithdrawResponse Withdraw(string accountNumber, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();
            response.Account = _accountRepository.LoadAccount(accountNumber);
            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"Account {response.Account} is not valid.";
                return response;
            }

            IWithdraw withdraw = WithdrawRulesFactory.Create(response.Account.Type);
            response = withdraw.Withdraw(response.Account,amount);   //account, oldbalance,amount

            if (response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }
            return response;
        }
    }
}
