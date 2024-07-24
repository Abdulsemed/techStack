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
    public class GetAllRecipesRequestHandler : IRequestHandler<GetAllRecipesRequest, BaseResponseClass>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        public GetAllRecipesRequestHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponseClass> Handle(GetAllRecipesRequest request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetAllAsync();
            var recipesDto = _mapper.Map<List<GetRecipesDto>>(recipes);
            BaseResponseClass response = new BaseResponseClass
            {
                Data = recipes,
                StatusCode = 200,
                Success = true,
            };

            return response;
        }
    }
}
