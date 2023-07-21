using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearTipoPersonaController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearTipoPersonaController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearTipoPersona(CrearTipoPersonaCommand command)
    {
        CrearTipoPersonaResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}