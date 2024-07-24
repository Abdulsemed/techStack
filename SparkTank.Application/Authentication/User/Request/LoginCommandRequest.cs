using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SparkTank.Application.Authentication.common;
using MediatR;

namespace SparkTank.Application.Authentication.Request
{
    public record LoginCommandRequest(string Email, string Password) : IRequest<AuthenticationResult>;
}