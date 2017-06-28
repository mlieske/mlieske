using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public enum AccountType
    {
        Free = 1, //would otherwise start at 0
        Basic,  //will be 2
        Premium //will be 3
    }
}
