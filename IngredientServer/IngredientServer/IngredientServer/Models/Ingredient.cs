using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        [Required]
        public string IngredientName { get; set; }

        [Required]
        public decimal IngredientPrice { get; set; } = 0;

        [Required]
        public string IngredientArticle { get; set; }
    }
}
