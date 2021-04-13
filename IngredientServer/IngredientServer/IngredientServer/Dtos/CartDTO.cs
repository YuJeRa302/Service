using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Dtos
{
    public class CartDTO
    {
        public int CartId { get; set; }

        public int ingredientId { get; set; }

        public string ingredientName { get; set; }

        public decimal ingredientPrice { get; set; } = 0;

    }
}
