using AutoMapper;
using MediatR;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace Store.Application.Features.Users.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
{
    private readonly UserManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> userManager;
    private readonly SignInManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> signInManager;

    public RegisterCommandHandler(UserManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> userManager, SignInManager<Microsoft.AspNet.Identity.EntityFramework.IdentityUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new Microsoft.AspNet.Identity.EntityFramework.IdentityUser() { UserName = request.UserName, Email = request.Email};

        var response = await userManager.CreateAsync(user, request.Password);

        if (response.Succeeded)
        {
            await signInManager.SignInAsync(user, isPersistent : false);

            return new() {Success = true, Message = "Created"};
        }

        return new() { Success = false, Message = "Failed"};
    }
}
