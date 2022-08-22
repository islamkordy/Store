using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Store.Application.Features.Users.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;

    public RegisterCommandHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new IdentityUser() { UserName = request.UserName, Email = request.Email};

        var response = await userManager.CreateAsync(user, request.Password);

        if (response.Succeeded)
        {
            await signInManager.SignInAsync(user, isPersistent : false);

            return new() {Success = true, Message = "Created"};
        }

        return new() { Success = false, Message = "Failed"};
    }
}
