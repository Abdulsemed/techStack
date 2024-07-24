using MediatR;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.Features.Recipe.Request.Commands;
using tech.Application.Persistence.Contracts;

namespace tech.Application.Features.Recipe.Handler.Commands
{
    public class DeleteRecipeRequestHandler : IRequestHandler<DeleteRecipeRequest, BaseResponseClass>
    {
        private readonly IRecipeRepository _recipeRepository;
        public DeleteRecipeRequestHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<BaseResponseClass> Handle(DeleteRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetAsync(request.RecipeId);
            BaseResponseClass response;
            if (recipe == null)
            {
                response = new BaseResponseClass
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Delete Failed"
                };
            }
            else if(recipe.UserEntityId != request.UserId)
            {
                response = new BaseResponseClass
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Ownership Error"
                };
            }
            else
            {
                await _recipeRepository.Delete(recipe);
                response = new BaseResponseClass
                {
                    StatusCode = 201,
                    Success = true,
                    Message = "recipe deleted"
                };
            }

            return response;
        }
    }
}
