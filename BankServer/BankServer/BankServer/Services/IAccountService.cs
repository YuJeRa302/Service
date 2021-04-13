using BankServer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankServer.Services
{
    public interface IAccountService : IDataService<AccountDto>
    {
        IEnumerable<AccountDto> GetAll();

        AccountDto GetByNumber(string number);
    }
}
