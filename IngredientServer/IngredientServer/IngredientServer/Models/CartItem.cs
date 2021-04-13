using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Models
{
    public class CartItem
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public string ingredientName { get; set; }

        [Required]
        public decimal ingredientPrice { get; set; } = 0;

    }
}
