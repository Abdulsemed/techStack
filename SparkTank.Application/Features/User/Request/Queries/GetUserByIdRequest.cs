using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SparkTank.Application.DTOs.UserDto;
using SparkTank.Application.Responses;

namespace SparkTank.Application.Features.User.Request.Queries
{
    public class GetUserByIdRequest: IRequest<BaseResponseClass>
    {
        public Guid Id { get; set; }
    }
}