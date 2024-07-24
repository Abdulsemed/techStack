using MediatR;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.DTOs.RecipesDto;

namespace tech.Application.Features.Recipe.Request.Commands
{
    public class UpdateRecipeCommand : IRequest<BaseResponseClass>
    {
        public UpdateRecipesDto UpdateRecipesDto { get; set; }
        public Guid UserId { get; set; }
    }
}
