using MediatR;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.DTOs.UserDto;

namespace tech.Application.Features.User.Request.Commands
{
    public class UpdateUserProfileRequest : IRequest<BaseResponseClass>
    {
        public Guid UserId { get; set; }
        public EditUserDto User { get; set; }
    }
}
