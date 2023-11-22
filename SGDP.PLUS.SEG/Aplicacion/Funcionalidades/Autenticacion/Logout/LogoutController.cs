using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Logout;

[Route("api/[controller]")]
[ApiController]
public class LogoutController : ControllerBase
{
    private readonly IMediator _mediator;
    public LogoutController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Logout()
    {
        await _mediator.Send(new LogoutCommand());

        return Ok();
    }
}
