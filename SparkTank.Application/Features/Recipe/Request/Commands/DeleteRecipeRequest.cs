using MediatR;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Application.Features.Recipe.Request.Commands
{
    public class DeleteRecipeRequest : IRequest<BaseResponseClass>
    {
        public Guid RecipeId { get; set; }
        public Guid UserId { get; set; }
    }
}
