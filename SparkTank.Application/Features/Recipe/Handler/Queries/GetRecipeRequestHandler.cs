using AutoMapper;
using MediatR;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.DTOs.RecipesDto;
using tech.Application.Features.Recipe.Request.Queries;
using tech.Application.Persistence.Contracts;

namespace tech.Application.Features.Recipe.Handler.Queries
{
    public class GetRecipeRequestHandler : IRequestHandler<GetRecipeRequest, BaseResponseClass>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        public GetRecipeRequestHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
        }
        public async Task<BaseResponseClass> Handle(GetRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetAsync(request.RecipeId);
            var recipeDto = _mapper.Map<GetRecipeDto>(recipe);
            BaseResponseClass response = new BaseResponseClass
            {
                Data = recipeDto,
                StatusCode = 200,
                Success = true,
            };

            return response;
        }
    }
}
