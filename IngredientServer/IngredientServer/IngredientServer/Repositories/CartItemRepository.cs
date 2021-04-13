using IngredientServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Repositories
{
    public class CartItemRepository : BaseRepository, ICartItemRepository
    {
        public CartItemRepository(IngredientServerContext context) : base(context) { }

        public IEnumerable<CartItem> FindAll()
        {
            return _context.CartItem.OrderBy(a => a.CartId);
        }

        public CartItem FindById(int id)
        {
            return _context.CartItem.AsNoTracking().FirstOrDefault(a => a.CartId == id);
        }

        public void Add(CartItem entity)
        {
            _context.Set<CartItem>().Add(entity);
        }

        public void Update(CartItem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<CartItem>().Update(entity);
        }

        public void Delete(CartItem entity)
        {
            _context.Set<CartItem>().Remove(entity);
        }

        public CartItem Save(CartItem entity)
        {
            _context.SaveChanges();
            return entity;
        }

        public bool EntityExists(int id)
        {
            return _context.CartItem.Any(a => a.CartId == id);
        }
    }
}
