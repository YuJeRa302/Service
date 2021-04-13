using AutoMapper;
using IngredientServer.Dtos;
using IngredientServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientServer.MapperProfiles
{
    public class IngredientMapperProfile : Profile
    {
        public IngredientMapperProfile()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto, Ingredient>();
        }
    }
}
