using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarPerfilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActivarInactivarPerfilesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{perfilId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivar(Guid perfilId)
    {
        ActivarInactivarPerfilesResponse response = await _mediator.Send(new ActivarInactivarPerfilesCommand(perfilId));

        return Ok(response);
    }
}
