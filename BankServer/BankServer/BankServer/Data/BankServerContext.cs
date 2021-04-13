using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankServer.Models
{
    public class BankServerContext : DbContext
    {
        public BankServerContext (DbContextOptions<BankServerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BankServer.Models.Account> Account { get; set; }
    }
}
