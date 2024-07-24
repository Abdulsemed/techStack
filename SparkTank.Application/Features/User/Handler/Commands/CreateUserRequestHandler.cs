using MediatR;
using AutoMapper;
using SparkTank.Application.Features.User.Request.Commands;
using SparkTank.Application.Responses;
using SparkTank.Domain.Entities;
using SparkTank.Application.DTOs.UserDto.Validators;
using SparkTank.Application.Persistence.Contracts;
using SparkTank.Application.Persistence.Contracts.Auth;


namespace SparkTank.Application.Features.User.Handler.Commands
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, BaseResponseClass>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUserRepository _UserRepository;
        private readonly IPasswordService _passwordService;
        // private readonly IEmailSender _emailSender;
        public CreateUserRequestHandler(
            IMapper mapper, 
            IUserRepository UserRepository, 
            // IEmailSender emailSender, 
            IMediator mediator,
            IPasswordService passwordService)
        {
            _mapper = mapper;
            _UserRepository = UserRepository;
            // _emailSender = emailSender;
            _mediator = mediator;
            _passwordService = passwordService;
        }

        public async Task<BaseResponseClass> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserValidator(_UserRepository);
            var validationResult = await validator.ValidateAsync(request.User, cancellationToken);
            var response = new BaseResponseClass();

            if (!validationResult.IsValid)
            {
                response = new BaseResponseClass
                {
                    Message = "User Creation Failed",
                    Success = false,
                    StatusCode = 400,
                    Error = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            else
            {
                // hash password
                var hashedPassword = _passwordService.HashPassword(request.User.Password);
                request.User.Password = hashedPassword;
                

                // add user to database
                var User = _mapper.Map<UserEntity>(request.User);
                await _UserRepository.Add(User);

               
       
                response = new BaseResponseClass
                {
                    Id = User.Id,
                    Message = "User Created Successfully",
                    Success = true,
                    StatusCode = 201,
                };
            }

            return response;
        }
    }
}