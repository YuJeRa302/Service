using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Models
{
    public class IngredientServerContext : DbContext
    {
        public IngredientServerContext(DbContextOptions<IngredientServerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<IngredientServer.Models.Ingredient> Ingredient { get; set; }

        public DbSet<IngredientServer.Models.CartItem> CartItem { get; set; }
    }
}
