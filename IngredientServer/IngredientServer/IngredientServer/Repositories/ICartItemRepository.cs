using IngredientServer.Dtos;
using IngredientServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Repositories
{
    public interface ICartItemRepository : IDataRepository<CartItem>
    {
        IEnumerable<CartItem> FindAll();

        CartItem FindById(int id);

        bool EntityExists(int id);
    }
}
