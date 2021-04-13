using BankServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankServer.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(BankServerContext context) : base(context) { }

        public IEnumerable<Account> FindAll()
        {
            return _context.Account.OrderBy(a => a.AccountId);
        }

        public Account FindById(int id)
        {
            return _context.Account.AsNoTracking().FirstOrDefault(a => a.AccountId == id);
        }

        public Account FindByNumber(string number)
        {
            return _context.Account.AsNoTracking().FirstOrDefault(a => a.AccountNumber.Equals(number));
        }

        public void Add(Account entity)
        {
            _context.Set<Account>().Add(entity);
        }

        public void Update(Account entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<Account>().Update(entity);
        }

        public void Delete(Account entity)
        {
            _context.Set<Account>().Remove(entity);
        }

        public Account Save(Account entity)
        {
            _context.SaveChanges();
            return entity;
        }

        public bool EntityExists(int id)
        {
            return _context.Account.Any(a => a.AccountId == id);
        }
    }
}
