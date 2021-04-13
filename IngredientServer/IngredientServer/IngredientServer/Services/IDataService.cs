using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Services
{
    public interface IDataService<T> where T : class
    {
        T GetById(int id);

        T Save(int id, T dto);

        void Delete(int id);

        bool EntityExists(int id);
    }
}
