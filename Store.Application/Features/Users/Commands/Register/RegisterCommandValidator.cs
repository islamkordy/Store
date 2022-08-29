using FluentValidation;

namespace Store.Application.Features.Users.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.UserName).NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(c => c.Email).EmailAddress().WithMessage("{PropertyName} is not in correct format");
        RuleFor(c => c.Password)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$")
            .WithMessage("{PropertyName} is not in correct format");
        RuleFor(c => c.ConfirmPassword)
            .Equal(c => c.Password)
            .WithMessage("ConfirmPassword is not the same as Password");
    }
}
