using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Dtos
{
    public class IngredientDto
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public decimal IngredientPrice { get; set; } = 0;

        public string IngredientArticle { get; set; }
    }
}
