using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarAplicacionesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActivarInactivarAplicacionesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{aplicacionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> ActivarInactivar(Guid aplicacionId)
    {
        ActivarInactivarAplicacionesResponse response = await _mediator.Send(new ActivarInactivarAplicacionesCommand(aplicacionId));

        return Ok(response);
    }
}
