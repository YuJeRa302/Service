using IngredientServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Repositories
{
    abstract public class BaseRepository
    {
        protected readonly IngredientServerContext _context;

        public BaseRepository(IngredientServerContext context)
        {
            _context = context;
        }
    }
}
