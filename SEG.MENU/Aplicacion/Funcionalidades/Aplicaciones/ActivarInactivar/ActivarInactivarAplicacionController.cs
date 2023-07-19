using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarAplicacionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActivarInactivarAplicacionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{aplicacionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> ActivarInactivarAplicacion(Guid aplicacionId)
    {
        ActivarInactivarAplicacionResponse response = await _mediator.Send(new ActivarInactivarAplicacionCommand(aplicacionId));

        return Ok(response);
    }
}
