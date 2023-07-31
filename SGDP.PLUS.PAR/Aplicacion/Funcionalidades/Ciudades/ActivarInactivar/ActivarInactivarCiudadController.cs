using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ActivarInactivar;

[Route("api/[controller]")]
[ApiController]
public class ActivarInactivarCiudadController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivarInactivarCiudadController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActivarInactivarCiudad(Guid CiudadId)
    {
        ActivarInactivarCiudadResponse response = await _mediator.Send(new ActivarInactivarCiudadCommand(CiudadId));

        return Ok(response);
    }
}