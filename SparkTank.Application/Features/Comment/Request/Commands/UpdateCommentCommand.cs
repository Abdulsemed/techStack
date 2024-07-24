using MediatR;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.DTOs.CommentsDto;

namespace tech.Application.Features.Comment.Request.Commands
{
    public class UpdateCommentCommand : IRequest<BaseResponseClass>
    {
        public UpdateCommentDto UpdateCommentDto { get; set; }
        public Guid UserId { get; set; }
    }
}
