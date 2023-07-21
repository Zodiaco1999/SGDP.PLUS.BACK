using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarTipoPersonaController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarTipoPersonaController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarTipoPersona(Guid tipopersonaId)
    {
        ActivarInactivarTipoPersonaResponse response = await _mediator.Send(new ActivarInactivarTipoPersonaCommand(tipopersonaId));

        return Ok(response);
    }
}