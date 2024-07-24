using FluentValidation;
using SparkTank.Application.Persistence.Contracts;

namespace SparkTank.Application.DTOs.UserDto.Validators
{
    public class CreateUserValidator: AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;
        private bool IsType(string type)
        {
            var userTypes = new List<String> { "startup", "investor" };
            var found = userTypes.FirstOrDefault(match=>match.Contains(type));
            return found != null;
        }
        public CreateUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(u => u.Email)
           .NotEmpty().WithMessage("{PropertyName} is required!")
           .EmailAddress().WithMessage("{PropertyName} is not a valid email address!");


            RuleFor(u => u.Email)
            .MustAsync(async (id, token) =>
            {
                var EmailExists = await _userRepository.GetByEmail(id);
                return EmailExists == null;
            }).WithMessage("{PropertyName} is already taken");


            RuleFor(u => u.Password)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .MinimumLength(8).WithMessage("{PropertyName} must be atleast 8 characters. ")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.")
            .Matches("[!@#$%^&*]").WithMessage("Password must contain at least one special character.");

            
        }
    }
}
