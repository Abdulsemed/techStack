using SparkTank.Application.DTOs.UserDto;
using SparkTank.Application.Responses;
using MediatR;

namespace SparkTank.Application.Features.User.Request.Commands
{
    public class CreateUserRequest : IRequest<BaseResponseClass>
    {
        public CreateUserDto User { get; set; }
    }
}