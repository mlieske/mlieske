﻿using Ninject;
using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            //AccountManager accountManager = AccountManagerFactory.Create();
            AccountManager accountManager = DIContainer.Kernel.Get<AccountManager>();

            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter a deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Deposit completed.");
                Console.WriteLine($"Account number: {response.Account.AccountNumber:c}");
                Console.WriteLine($"Old balance: {response.OldBalance:c}");
                Console.WriteLine($"Deposit amount: {response.Amount:c}");
                Console.WriteLine($"New balance: {response.Account.Balance:c}");

            }
            else
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
