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
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public IEnumerable<IngredientDto> GetAll()
        {
            return _ingredientRepository.FindAll().Select(a => _mapper.Map<IngredientDto>(a));
        }

        public IngredientDto GetById(int id)
        {
            return _mapper.Map<IngredientDto>(_ingredientRepository.FindById(id));
        }

        public IngredientDto GetByArticle(string article)
        {
            return _mapper.Map<IngredientDto>(_ingredientRepository.FindByArticle(article));
        }

        public IngredientDto Save(int id, IngredientDto dto)
        {
            Ingredient ingredient = _mapper.Map<Ingredient>(dto);
            if (id != 0)
            {
                ingredient.IngredientId = id;
                _ingredientRepository.FindById(id).IngredientName = ingredient.IngredientName;
                _ingredientRepository.FindById(id).IngredientArticle = ingredient.IngredientArticle;
                _ingredientRepository.FindById(id).IngredientPrice = ingredient.IngredientPrice;
                _ingredientRepository.Update(ingredient);
            }
            else
            {
                _ingredientRepository.Add(ingredient);
                ingredient = _ingredientRepository.Save(ingredient);
                _ingredientRepository.Update(ingredient);
            }
            return _mapper.Map<IngredientDto>(_ingredientRepository.Save(ingredient));
        }

        public void Delete(int id)
        {
            Ingredient ingredient = _ingredientRepository.FindById(id);
            _ingredientRepository.Delete(ingredient);
            _ingredientRepository.Save(ingredient);
        }

        public bool EntityExists(int id)
        {
            return _ingredientRepository.EntityExists(id);
        }
    }
}
