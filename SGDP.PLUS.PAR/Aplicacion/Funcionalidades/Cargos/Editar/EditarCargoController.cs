using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Editar;

[Route("api/[controller]")]
[ApiController]
public class EditarCargoController : ControllerBase
{
    private readonly IMediator _mediator;
    public EditarCargoController(IMediator mediator) => _mediator = mediator;

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EditarCargo(EditarCargoCommand command)
    {
        EditarCargoResponse response = await _mediator.Send(command);

        return Ok(response);
    }
}