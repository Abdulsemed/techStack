using MediatR;
using SparkTank.Application.DTOs.Authentication;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.Authentication.User.Request;

public class ResetPasswordCommand : IRequest<BaseResponseClass>
{
    public ResetPasswordDto ResetPassword { get; set; }
}
