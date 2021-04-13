using IngredientServer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Services
{
    public interface ICartItemService : IDataService<CartDTO>
    {
        IEnumerable<CartDTO> GetAll();

    }
}
