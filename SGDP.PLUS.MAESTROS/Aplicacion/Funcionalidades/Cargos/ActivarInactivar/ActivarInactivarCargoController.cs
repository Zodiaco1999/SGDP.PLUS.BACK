using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarCargoController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarCargoController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{cargoId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarCargo(Guid CargoId)
    {
        ActivarInactivarCargoResponse response = await _mediator.Send(new ActivarInactivarCargoCommand(CargoId));

        return Ok(response);
    }
}