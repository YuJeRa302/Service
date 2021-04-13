using IngredientServer.Dtos;
using IngredientServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET: api/Ingedients
        [HttpGet]
        public IEnumerable<IngredientDto> GetIngredient()
        {
            return _ingredientService.GetAll();
        }

        // GET: api/Ingedients/5
        [HttpGet("{id}")]
        public ActionResult<IngredientDto> GetIngredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IngredientDto ingredientDto = _ingredientService.GetById(id);

            if (ingredientDto == null)
            {
                return NotFound();
            }

            return Ok(ingredientDto);
        }

        // PUT: api/Ingedients/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutIngredient([FromRoute] int id, [FromBody] IngredientDto ingredientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredientDto.IngredientId)
            {
                return BadRequest();
            }
            try
            {
                ingredientDto = _ingredientService.Save(id, ingredientDto);
            }
            catch 
            {
                return BadRequest("Not enough money in the account!");
            }

            if (!IngredientExists(id))
            {
                return NotFound();
            }

            return Ok(ingredientDto);
        }

        // PUT: api/Ingedients/byArticle/00001234
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("byArticle/{article}")]
        public IActionResult PutIngredientByArticle([FromRoute] string number, [FromBody] IngredientDto ingredientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!number.Equals(ingredientDto.IngredientArticle))
            {
                return BadRequest();
            }

            IngredientDto findedByArticleDto;

            try
            {
                findedByArticleDto = _ingredientService.GetByArticle(ingredientDto.IngredientArticle);
                if (findedByArticleDto != null)
                {
                    findedByArticleDto.IngredientName = ingredientDto.IngredientName;
                    findedByArticleDto.IngredientArticle = ingredientDto.IngredientArticle;
                    findedByArticleDto.IngredientPrice = ingredientDto.IngredientPrice;
                    findedByArticleDto = _ingredientService.Save(findedByArticleDto.IngredientId, findedByArticleDto);
                }
                else
                {
                    return NotFound("Ingredient not found!");
                }
            }

            catch
            {
                return BadRequest("Not enough money in the account!");
            }

            return Ok();
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<IngredientDto> PostIngredient([FromBody] IngredientDto ingredientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IngredientDto newIngredient = _ingredientService.Save(0, ingredientDto);

            return CreatedAtAction("GetIngredient", new { id = newIngredient.IngredientId, name = newIngredient.IngredientName, article = newIngredient.IngredientArticle, price = newIngredient.IngredientPrice }, newIngredient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public ActionResult<IngredientDto> DeleteIngredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!IngredientExists(id))
            {
                return NotFound();
            }

            _ingredientService.Delete(id);

            return Ok();
        }

        private bool IngredientExists(int id)
        {
            return _ingredientService.EntityExists(id);
        }
    }
}
