using IngredientServer.Dtos;
using IngredientServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Repositories
{
    public interface IIngredientRepository : IDataRepository<Ingredient>
    {
        IEnumerable<Ingredient> FindAll();

        Ingredient FindById(int id);

        Ingredient FindByArticle(string article);

        bool EntityExists(int id);
    }
}
