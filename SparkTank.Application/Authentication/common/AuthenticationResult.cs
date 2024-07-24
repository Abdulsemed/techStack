using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SparkTank.Domain.Entities;

namespace SparkTank.Application.Authentication.common
{
    public record AuthenticationResult(UserEntity User, string Token, bool Success, string Message, bool Verified, int StatusCode);
}