using SparkTank.Application.Responses;
using MediatR;
using SparkTank.Application.DTOs.Authentication;    

namespace SparkTank.Application.Authentication.Request
{

    public class ForgetPasswordCommand : IRequest<BaseResponseClass>
    {
        public ForgetPasswordDto forgetPasswordDto { get; set; }
    }
}
