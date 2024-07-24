using MediatR;
using Microsoft.AspNetCore.Mvc;
using SparkTank.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;
using SparkTank.Application.DTOs.UserDto;
using SparkTank.Application.Features.User.Request.Commands;
using SparkTank.Application.Features.User.Request.Queries;
using tech.Application.Features.User.Request.Commands;
using tech.Application.DTOs.UserDto;


namespace SparkTank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<BaseResponseClass>> CreateUser([FromBody] CreateUserDto createuserdto)
        {
            var command = new CreateUserRequest {User = createuserdto };
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        //future admin authorization
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<BaseResponseClass>> GetAllUsers()
        {
            var query = new GetAllUsersRequest();
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }
        [Authorize]
        [HttpGet]
        [Route("GetUserProfile")]
        public async Task<ActionResult<BaseResponseClass>> GetUsers()
        {
            var userId = new Guid(_contextAccessor.HttpContext!.User.FindFirstValue("userid"));
            var query = new GetUserByIdRequest {Id = userId};
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        [Authorize]
        [Route("EditProfile")]
        public async Task<ActionResult<BaseResponseClass>> EditProfile(EditUserDto editUserDto)
        {
            var userId = new Guid(_contextAccessor.HttpContext!.User.FindFirstValue("userid"));
            var command = new UpdateUserProfileRequest { UserId = userId, User = editUserDto};
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }
    }  
}