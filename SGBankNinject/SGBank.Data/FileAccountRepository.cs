using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        List<Account> accounts = new List<Account>();//putting the data into this
        string path = @"c:\sgbitbucket\michele-lieske-individual-work\SGBankNinject\Accounts.txt";
        private static Account _account = new Account();
        
        public Account LoadAccount(string accountNumber)
        {
            string getType;
            _account.AccountNumber = null;
            string[] rows = File.ReadAllLines(path);
            
            for (int i = 1; i < rows.Length; i++) //skips the header row
            {
                string[] columns = rows[i].Split(',');

                Account a = new Account();
                a.AccountNumber = columns[0];
                a.Name = columns[1];
                a.Balance = decimal.Parse(columns[2]);
                getType = columns[3];

                switch (getType)
                {
                    case "F":
                        a.Type = AccountType.Free;
                        break;
                    case "B":
                        a.Type = AccountType.Basic;
                        break;
                    case "P":
                        a.Type = AccountType.Premium;
                        break;
                    default:
                        throw new Exception("Data file has incorrect account type.");
                }

                if(a.AccountNumber == accountNumber)
                {
                    _account = a;
                }

                accounts.Add(a);
            }
            if (_account.AccountNumber != null)
            {
                return _account;
            }
            else
            {
                return null;
            }
            
        }

        public void SaveAccount(Account account)
        {
            var accountsToKeep = accounts.Where(a => a.AccountNumber != account.AccountNumber).ToList();
            string acctTypeLetter;
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (var acct in accountsToKeep)
                {
                    acctTypeLetter = acct.Type.ToString().Substring(0,1);
                    writer.WriteLine($"{acct.AccountNumber},{acct.Name},{acct.Balance},{acctTypeLetter}");
                }
                writer.WriteLine($"{account.AccountNumber},{account.Name},{account.Balance},{account.Type.ToString().Substring(0,1)}");
            }

            
        }
    }
}
