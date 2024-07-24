using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SparkTank.Application.Responses;
using System.Security.Claims;
using tech.Application.DTOs.CommentsDto;
using tech.Application.Features.Comment.Request.Commands;

namespace tech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;

        public CommentController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("CreateComment")]
        [Authorize]
        public async Task<ActionResult<BaseResponseClass>> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            var userId = new Guid(_contextAccessor.HttpContext!.User.FindFirstValue("userid"));
            var command = new CreateCommentCommand { CreateCommentDto = createCommentDto, UserId = userId };
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);

        }

        [Authorize]
        [HttpPut]
        [Route("UpdateComment")]
        public async Task<ActionResult<BaseResponseClass>> UpdateComment([FromBody] UpdateCommentDto updateCommentDto)
        {
            var userId = new Guid(_contextAccessor.HttpContext!.User.FindFirstValue("userid"));
            var command = new UpdateCommentCommand { UpdateCommentDto = updateCommentDto, UserId = userId } ;
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }
    }
}

