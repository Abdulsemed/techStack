using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SparkTank.Application.Responses;
using System.Security.Claims;
using tech.Application.DTOs.RecipesDto;
using tech.Application.Features.Recipe.Request.Commands;
using tech.Application.Features.Recipe.Request.Queries;

namespace tech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;

        public RecipeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = httpContextAccessor;
        }
        [HttpGet]
        [Route("GetAllRecipes")]
        public async Task<ActionResult<BaseResponseClass>> GetAllRecipes()
        {
            var request = new GetAllRecipesRequest { };
            var result = await _mediator.Send(request);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet]
        [Route("GetRecipe")]
        public async Task<ActionResult<BaseResponseClass>> GetRecipe(Guid Id)
        {
            var request = new GetRecipeRequest { RecipeId = Id };
            var result = await _mediator.Send(request);
            return StatusCode(result.StatusCode, result);
        }
        [Authorize]
        [HttpPost]
        [Route("CreateRecipe")]
        public async Task<ActionResult<BaseResponseClass>> CreateRecipe([FromBody] CreateRecipeDto createRecipeDto)
        {
            var userId = new Guid(_contextAccessor.HttpContext!.User.FindFirstValue("userid"));
            var command = new CreateRecipeRequest { CreateRecipeDto = createRecipeDto, UserId = userId };
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateRecipe")]
        public async Task<ActionResult<BaseResponseClass>> UpdateRecipe([FromBody] UpdateRecipesDto updateRecipesDto)
        {
            var userId = new Guid(_contextAccessor.HttpContext!.User.FindFirstValue("userid"));
            var command = new UpdateRecipeCommand { UpdateRecipesDto = updateRecipesDto, UserId = userId };
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteRecipe")]
        public async Task<ActionResult<BaseResponseClass>> DeleteRecipe(Guid Id)
        {
            var userId = new Guid(_contextAccessor.HttpContext!.User.FindFirstValue("userid"));
            var command = new DeleteRecipeRequest { RecipeId = Id, UserId = userId };
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);

        }
    }
}
