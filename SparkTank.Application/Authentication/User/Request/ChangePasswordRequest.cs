using MediatR;
using SparkTank.Application.DTOs.Authentication;
using SparkTank.Application.Responses;

namespace SparkTank.Application.Authentication.Request
{
    public class ChangePasswordRequest : IRequest<BaseResponseClass>
    {
        public ChangePasswordDto ChangePassword { get; set; }
        public Guid UserId { get; set; }
    }
}
