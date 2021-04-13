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
    public class CartController : ControllerBase
    {
        private readonly ICartItemService _cartService;

        public CartController(ICartItemService cartService)
        {
            _cartService = cartService;
        }

        // GET: api/cart
        [HttpGet]
        public IEnumerable<CartDTO> GetCartItem()
        {
            return _cartService.GetAll();
        }

        // GET: api/cart/5
        [HttpGet("{id}")]
        public ActionResult<CartDTO> GetCartItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CartDTO cartDto = _cartService.GetById(id);

            if (cartDto == null)
            {
                return NotFound();
            }

            return Ok(cartDto);
        }

        // PUT: api/cart/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutCartItem([FromRoute] int id, [FromBody] CartDTO cartDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartDto.CartId)
            {
                return BadRequest();
            }
            try
            {
                cartDto = _cartService.Save(id, cartDto);
            }
            catch
            {
                return BadRequest("Not enough money in the account!");
            }

            if (!CartItemExists(id))
            {
                return NotFound();
            }

            return Ok(cartDto);
        }

        // POST: api/cart
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<CartDTO> PostIngredient([FromBody] CartDTO cartDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _cartService.Save(0, cartDto);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public ActionResult<CartDTO> DeleteIngredient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CartItemExists(id))
            {
                return NotFound();
            }

            _cartService.Delete(id);

            return Ok();
        }

        private bool CartItemExists(int id)
        {
            return _cartService.EntityExists(id);
        }

    }
}
