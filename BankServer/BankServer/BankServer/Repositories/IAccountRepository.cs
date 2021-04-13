using BankServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankServer.Repositories
{
    public interface IAccountRepository : IDataRepository<Account>
    {
        IEnumerable<Account> FindAll();

        Account FindById(int id);

        Account FindByNumber(string number);

        bool EntityExists(int id);
    }
}
