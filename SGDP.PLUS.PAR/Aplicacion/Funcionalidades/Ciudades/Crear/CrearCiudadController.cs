using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Crear;

[Route("api/[controller]")]
[ApiController]
public class CrearCiudadController : ControllerBase
{
    private readonly IMediator _mediator;
    public CrearCiudadController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CrearCiudad(CrearCiudadCommand command)
    {
        CrearCiudadResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}