using FluentValidation;
using Tasks.Application.DTO.User;

namespace Tasks.Application.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator() 
        {
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("User name is required.")
                .MaximumLength(100)
                .WithMessage("User name must not exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.")
                .MaximumLength(150)
                .WithMessage("Email must not exceed 150 characters.");
        }
    }
}
