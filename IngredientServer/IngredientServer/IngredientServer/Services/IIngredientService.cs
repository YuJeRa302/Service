using IngredientServer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Services
{
    public interface IIngredientService : IDataService<IngredientDto>
    {
        IEnumerable<IngredientDto> GetAll();

        IngredientDto GetByArticle(string article);
    }
}
