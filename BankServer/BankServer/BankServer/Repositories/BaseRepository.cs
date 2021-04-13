using BankServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankServer.Repositories
{
    abstract public class BaseRepository
    {
        protected readonly BankServerContext _context;

        public BaseRepository(BankServerContext context)
        {
            _context = context;
        }
    }
}
