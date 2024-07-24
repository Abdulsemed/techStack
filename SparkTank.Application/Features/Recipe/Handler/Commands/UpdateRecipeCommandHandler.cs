using AutoMapper;
using MediatR;
using SparkTank.Application.Persistence.Contracts;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.Features.Recipe.Request.Commands;
using tech.Application.Persistence.Contracts;

namespace tech.Application.Features.Recipe.Handler.Commands;
public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, BaseResponseClass>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository, IUserRepository userRepository, IMapper mapper)
    {
        _recipeRepository = recipeRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<BaseResponseClass> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetAsync(request.UpdateRecipesDto.Id);
        BaseResponseClass response;
        if(recipe == null)
        {
            response = new BaseResponseClass
            {
                StatusCode = 400,
                Success = false,
                Message = "update failed"
            };
        }
        else if(recipe.UserEntityId != request.UserId)
        {
            response = new BaseResponseClass
            {
                StatusCode = 400,
                Success = false,
                Message = "ownership error"
            };
        }
        else
        {
            _mapper.Map(recipe, request.UpdateRecipesDto);

            await _recipeRepository.Update(recipe);

            response = new BaseResponseClass
            {
                StatusCode = 201,
                Success = true,
                Message = "Updated recipe"
            };
        }

        return response;
    }
}
