using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearCargoController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearCargoController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearCargo(CrearCargoCommand command)
    {
        CrearCargoResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}