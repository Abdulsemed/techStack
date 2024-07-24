using AutoMapper;
using MediatR;
using SparkTank.Application.Persistence.Contracts;
using SparkTank.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.Features.User.Request.Commands;

namespace tech.Application.Features.User.Handler.Commands;

public class UpdateUserProfileRequestHandler : IRequestHandler<UpdateUserProfileRequest, BaseResponseClass>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UpdateUserProfileRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<BaseResponseClass> Handle(UpdateUserProfileRequest request, CancellationToken cancellationToken)
    {
        BaseResponseClass responseClass;
        var user = await _userRepository.GetAsync(request.UserId);
        if (user == null)
        {
            responseClass = new BaseResponseClass
            {
                Success = false,
                Message = "user not found"
            };
        }
        else
        {
            _mapper.Map(user, request.User);
            await _userRepository.Update(user);
            responseClass = new BaseResponseClass
            {
                StatusCode = 200,
                Success = true,
                Message = "profile updated"
            };
        }

        return responseClass;
    }
}
