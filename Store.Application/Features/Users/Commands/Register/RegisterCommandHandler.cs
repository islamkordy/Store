using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Store.Application.Features.Users.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly IValidator<RegisterCommand> validator;

    public RegisterCommandHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IValidator<RegisterCommand> validator)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.validator = validator;
    }

    public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            throw new Exceptions.ValidationException(validationResult);

        var user = new IdentityUser() { UserName = request.UserName, Email = request.Email};

        var response = await userManager.CreateAsync(user, request.Password);

        if (!response.Succeeded)
            throw new Exceptions.InternalServiceError("Register failed");
         
        await signInManager.SignInAsync(user, isPersistent : false);

        return new() {Success = true, Message = "Created"};
    }
}
