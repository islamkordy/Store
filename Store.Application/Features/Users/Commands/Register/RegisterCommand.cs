using MediatR;

namespace Store.Application.Features.Users.Commands.Register;

public class RegisterCommand : IRequest<RegisterCommandResponse>
{
    public string  Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string UserName { get; set; }
}
