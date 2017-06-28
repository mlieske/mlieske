using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models.Responses
{
    public class AccountDepositResponse : Response
    {
        public Account Account { get; set; } //to hold the new balance information
        public decimal Amount { get; set; } //the amount that was deposited
        public decimal OldBalance { get; set; }
    }
}
