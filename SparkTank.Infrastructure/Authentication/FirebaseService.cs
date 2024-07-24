using AutoMapper;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json.Linq;
using SparkTank.Application.Authentication.common;
using SparkTank.Application.DTOs.UserDto;
using SparkTank.Application.Persistence.Contracts;
using SparkTank.Application.Persistence.Contracts.Auth;
using SparkTank.Application.Responses;
using SparkTank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Infrastructure.Authentication;

public class FirebaseService : IFirebaseService
{
    //private readonly IUserRepository _userRepository;
    //private readonly IMapper _mapper;
    //private readonly IJwtTokenGenerator _jwtTokenGenerator;
    //public FirebaseService(IUserRepository userRepository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
    //{
    //    _userRepository = userRepository;
    //    _mapper = mapper;
    //    _jwtTokenGenerator = jwtTokenGenerator;

    //}
    //public async Task<AuthenticationResult> RegisterUser(string fbtoken, string userType)
    //{
    //    BaseResponseClass response;
    //    FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(fbtoken);
    //    bool flag = false;
    //    var token = "";
    //    if (decodedToken == null)
    //    {
    //        response = new BaseResponseClass
    //        {
    //            Message = "failed login",
    //            Success = false
    //        };
    //        return new AuthenticationResult(null, token, response.Success, response.Message, flag, response.StatusCode);
    //    }
    //    else
    //    {
    //        var claims = decodedToken.Claims;
    //        var email = claims["email"].ToString();
    //        var user = await _userRepository.GetByEmail(email);
    //        if (user == null)
    //        {
    //            CreateUserDto userEntity = new CreateUserDto
    //            {
    //                Email = email,
    //                User_Type = userType,
    //                Password = "Pass@1234"
    //            };
    //            var newUser = _mapper.Map<UserEntity>(userEntity);
    //            await _userRepository.Add(newUser);
    //            user = newUser;
    //        }
    //        token = _jwtTokenGenerator.GenerateToken(user);
    //        flag = true;
    //        response = new BaseResponseClass
    //        {
    //            Success = true,
    //            Message = "User logged in successfully",
    //            StatusCode = 200
    //        };

    //        return new AuthenticationResult(user, token, response.Success, response.Message, flag, response.StatusCode);
    //    }


    //}
    public Task<AuthenticationResult> RegisterUser(string fbToken, string userType)
    {
        throw new NotImplementedException();
    }
}
