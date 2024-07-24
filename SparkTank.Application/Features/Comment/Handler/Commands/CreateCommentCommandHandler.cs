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
using tech.Domain.Entities;

namespace tech.Application.Features.Comment.Handler.Commands
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseResponseClass>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, IRecipeRepository recipeRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _recipeRepository = recipeRepository;
        }

        public async Task<BaseResponseClass> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<CommentEntity>(request.CreateCommentDto);
            comment.UserId = request.UserId;
            var recipe = await _recipeRepository.GetAsync(request.CreateCommentDto.RecipeId);
            BaseResponseClass response;
            if (recipe == null)
            {
                response = new BaseResponseClass
                {
                    StatusCode = 400,
                    Success = false,
                    Message = "creation failed"
                };
            }
            else
            {
                comment.UserId = request.UserId;

                await _commentRepository.Add(comment);
                response = new BaseResponseClass
                {
                    StatusCode = 201,
                    Success = true,
                    Message = "creation successful"
                };
            }

            return response;
        }
    }
}
