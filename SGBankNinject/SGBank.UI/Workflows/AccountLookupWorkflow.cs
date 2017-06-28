using Ninject;
using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class AccountLookupWorkflow
    {
        public void Execute()
        {
            AccountManager acctManager = DIContainer.Kernel.Get<AccountManager>();
            //AccountManager acctManager = AccountManagerFactory.Create(); //accountmanagerfactory will check app.comfig

            Console.Clear();
            Console.WriteLine("Account Number Lookup");
            Console.WriteLine("----------------------------");
            Console.Write("Enter an account number:  ");
            string accountNumber = Console.ReadLine();

            AccountLookupResponse response = acctManager.LookupAccount(accountNumber);

            if (response.Success)
            {
                ConsoleIO.DisplayAccountDetails(response.Account);
            }
            else
            {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
