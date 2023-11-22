using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarCiudadController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarCiudadController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarCiudad(EditarCiudadCommand command)
    {
        EditarCiudadResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}