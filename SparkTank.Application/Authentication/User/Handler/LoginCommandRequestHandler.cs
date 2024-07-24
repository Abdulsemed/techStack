using SparkTank.Application.Authentication.common;
using SparkTank.Application.Authentication.Request;
using SparkTank.Application.Persistence.Contracts;
using SparkTank.Application.Persistence.Contracts.Auth;
using SparkTank.Domain.Entities;
using SparkTank.Application.Responses;
using MediatR;

namespace SparkTank.Application.Authentication.User.Handler
{
    public sealed class LoginCommandRequestHandler : IRequestHandler<LoginCommandRequest, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;
        
        public LoginCommandRequestHandler(
            IJwtTokenGenerator jwtTokenGenerator, 
            IPasswordService passwordService, 
            IUserRepository userRepository 
            
            )
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _passwordService = passwordService;
            
        }

        public async Task<AuthenticationResult> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseClass();
            var user = await _userRepository.GetByEmail(request.Email);
            var token = "";
            bool flag = false;
            bool profileExist = false;
            
            if (user == null){
                response.Success = false;
                response.Message = "User email or password is incorrect";
                response.StatusCode = 400;
            }
            

            else if (!_passwordService.VerifyPassword(request.Password, user.Password))
            {
                response.Success = false;
                response.Message = "User email or password is incorrect";
                response.StatusCode = 400;
            }
            else
            {
                response.Success = true;
                response.Message = "User logged in successfully";
                response.StatusCode = 200;
                var companyImage = "";
                var companyName = "";
                
                token = _jwtTokenGenerator.GenerateToken(user, false,companyImage, companyName, profileExist);
                flag = true;
            }
   
            return new AuthenticationResult(user, token, response.Success, response.Message,flag, response.StatusCode);
        }
    }
}
