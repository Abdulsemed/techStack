using MediatR;
using SparkTank.Application.DTOs.UserDto;
using SparkTank.Application.Responses;

namespace SparkTank.Application.Features.User.Request.Queries
{
    public class GetAllUsersRequest : IRequest<BaseResponseClass>
    {
    }
}
