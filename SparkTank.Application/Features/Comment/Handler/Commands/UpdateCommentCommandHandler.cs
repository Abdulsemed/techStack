using AutoMapper;
using MediatR;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.Features.Comment.Request.Commands;
using tech.Application.Persistence.Contracts;

namespace tech.Application.Features.Comment.Handler.Commands
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, BaseResponseClass>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        public UpdateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository, IRecipeRepository recipeRepository)
        {
            _commentRepository = commentRepository;
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponseClass> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetAsync(request.UpdateCommentDto.Id);
            BaseResponseClass response;
            if(comment == null)
            {
                response = new BaseResponseClass
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Update Failed"
                };
            }
            else if(request.UserId != comment.UserId)
            {
                response = new BaseResponseClass
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "owner error"
                };
            }
            else
            {
                _mapper.Map(comment, request.UpdateCommentDto);
                await _commentRepository.Update(comment);
                response = new BaseResponseClass
                {
                    StatusCode = 201,
                    Success = true,
                    Message = "comment updated"
                };
            }

            return response;
        }
    }
}
