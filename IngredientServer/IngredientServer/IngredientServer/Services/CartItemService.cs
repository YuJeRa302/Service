using AutoMapper;
using IngredientServer.Dtos;
using IngredientServer.Models;
using IngredientServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public CartItemService(ICartItemRepository cartRepository, IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public IEnumerable<CartDTO> GetAll()
        {
            return _cartRepository.FindAll().Select(a => _mapper.Map<CartDTO>(a));
        }

        public CartDTO GetById(int id)
        {
            return _mapper.Map<CartDTO>(_cartRepository.FindById(id));
        }

        public CartDTO Save(int id, CartDTO dto)
        {
            CartItem modifiedCartItem = _mapper.Map<CartItem>(dto);

            Ingredient ingredient = _ingredientRepository.FindById(dto.ingredientId);

            modifiedCartItem.ingredient = ingredient;

            if (id != 0)
            {
                modifiedCartItem.CartId = id;
                _cartRepository.FindById(id).ingredient.IngredientId = modifiedCartItem.ingredient.IngredientId;
                _cartRepository.FindById(id).ingredient.IngredientName = modifiedCartItem.ingredient.IngredientName;
                _cartRepository.FindById(id).ingredient.IngredientPrice = modifiedCartItem.ingredient.IngredientPrice;
                _cartRepository.Update(modifiedCartItem);
            }

            return _mapper.Map<CartDTO>(_cartRepository.Save(modifiedCartItem));

        }

        public void Delete(int id)
        {
            CartItem cartItem = _cartRepository.FindById(id);
            _cartRepository.Delete(cartItem);
            _cartRepository.Save(cartItem);
        }

        public bool EntityExists(int id)
        {
            return _cartRepository.EntityExists(id);
        }
    }
}
