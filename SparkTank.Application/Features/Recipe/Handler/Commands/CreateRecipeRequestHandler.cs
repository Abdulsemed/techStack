using AutoMapper;
using MediatR;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.DTOs.RecipesDto;
using tech.Application.Features.Recipe.Request.Commands;
using tech.Application.Persistence.Contracts;
using tech.Domain.Entities;

namespace tech.Application.Features.Recipe.Handler.Commands
{
    public class CreateRecipeRequestHandler : IRequestHandler<CreateRecipeRequest, BaseResponseClass>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        public CreateRecipeRequestHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;

        }
        public async Task<BaseResponseClass> Handle(CreateRecipeRequest request, CancellationToken cancellationToken)
        {
            BaseResponseClass response;
            var recipe = _mapper.Map<RecipeEntity>(request.CreateRecipeDto);
            recipe.UserEntityId = request.UserId;

            await _recipeRepository.Add(recipe);
            response = new BaseResponseClass
            {
                StatusCode = 201,
                Success = true,
                Message = "recipe created"
            };

            return response;

        }
    }
}
