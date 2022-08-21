using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Features.Users.Commands.Register;
using System.Threading.Tasks;

namespace Store.API.Controllers;

public class AccountController : ControllerBase
{
    private readonly IMediator mediator;

    public AccountController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Create([FromBody] RegisterCommand registerCommand)
    {
        var response = await mediator.Send(registerCommand);

        return Ok(response);
    }
}
