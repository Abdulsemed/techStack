using SparkTank.Application.Authentication.Request;
using SparkTank.Application.Persistence.Contracts;
using SparkTank.Application.Persistence.Contracts.Auth;
using MediatR;
using SparkTank.Application.DTOs.Authentication.Validator;
using SparkTank.Application.Responses;

namespace SparkTank.Application.Authentication.User.Handler
{
    public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequest, BaseResponseClass>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public ChangePasswordRequestHandler(
            IUserRepository userRepository,
            IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }
        public async Task<BaseResponseClass> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            // check user exists
            var user = await _userRepository.GetAsync(request.UserId);
            var validator = new ChangePasswordValidator();
            var validated = await validator.ValidateAsync(request.ChangePassword);
            var response = new BaseResponseClass();
            if (user == null)
            {
                response = new BaseResponseClass
                {
                    Message = "Change Password Failed",
                    Success = false,
                    StatusCode = 400,
                    Error = new List<string> { "User does not exist" }
                };
            }
            else if (!validated.IsValid)
            {
                response = new BaseResponseClass
                {
                    Message = "Change Password Failed",
                    Success = false,
                    StatusCode = 400,
                    Error = validated.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            else if(!_passwordService.VerifyPassword(request.ChangePassword.OldPassword, user.Password))
            {
                response = new BaseResponseClass
                {
                    Message = "Change Password Failed",
                    Success = false,
                    StatusCode = 400,
                    Error = new List<string> { "wrong old password" }
                };
            }
            else
            {
                // update password
                request.ChangePassword.NewPassword = _passwordService.HashPassword(request.ChangePassword.NewPassword);
                user.Password = request.ChangePassword.NewPassword;
                await _userRepository.Update(user);
                response = new BaseResponseClass
                {
                    Message = "Password Changed Successfully",
                    Success = true,
                    StatusCode = 201,
                    Id = user.Id,
                };
            }
            return response;
        }
    }
}
