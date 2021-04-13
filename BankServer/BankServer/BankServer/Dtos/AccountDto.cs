using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankServer.Dtos
{
    public class AccountDto
    {
        public int AccountId { get; set; }

        public string AccountNumber { get; set; }

        public decimal AccountMoney { get; set; } = 0;
    }
}
