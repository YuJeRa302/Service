using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Dtos
{
    public class AccountDTO
    {
        public string accountNumber { get; set; }

        public decimal accountMoney { get; set; } = 0;
    }
}
