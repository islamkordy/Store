using MediatR;

namespace Store.Application.Features.Users.Commands.Register;

public class RegisterCommand : IRequest<RegisterCommandResponse>
{
    public string  Email { get; set; }

    //[DataType(DataType.Password)]
    public string Password { get; set; }

    //[DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    public string UserName { get; set; }
}
